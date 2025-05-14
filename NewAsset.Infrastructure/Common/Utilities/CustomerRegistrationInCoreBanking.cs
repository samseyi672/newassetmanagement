using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAsset.Infrastructure.Common.Utilities
{
    public class CustomerRegistrationInCoreBanking
    {
        public static async Task<GenericApiResponse<RegistrationResponse>> processRegistrationForExistingCustomerInCoreBanking(IBackOfficeCustomerChecker _backOfficeCustomerChecker, ICoreBankingService _coreBankingService, FinedgeSearchBvn cbaResponse, IUnitOfWork _unitOfWork, Registration Registraion, string session, string otp, AssetCapitalInsuranceRegistrationRequest Request, string uniRef)
        {
            var bvnDetail2 = await _coreBankingService.ValidateAssetCapitalInsuranceBvn(Request.Bvn, _unitOfWork);
            if (!bvnDetail2.Success)
            {
                GenericApiResponse<RegistrationResponse>.FailureResponse(CustomerEnumResponse.InvalidBvn.GetDescription());
            }
            _unitOfWork.GetRepository<IRegistrationRepository>().AddRegistration(new Registration()
            {
                id = Registraion.id,
                LastName = cbaResponse.result.lastname,
                phoneNumber = cbaResponse.result.mobile,
                CustomerId = cbaResponse.result.customerID,
                FirstName = cbaResponse.result.firstname
            });
            var IsCustomerExist = await _backOfficeCustomerChecker.IsCustomerExistInBackOffice(Request.Email, Request.UserType);
            if (!IsCustomerExist.Success)
            {
                return GenericApiResponse<RegistrationResponse>.FailureResponse(CustomerEnumResponse.CustomerValidationUnSuccessful.GetDescription());
            }
            SimplexCustomerCheckerResponse simplexCustomerCheckerResponse5 = JsonConvert.DeserializeObject<SimplexCustomerCheckerResponse>(JsonConvert.SerializeObject(IsCustomerExist?.Data));
            var hasSimplexAccount2 = simplexCustomerCheckerResponse5 != null ? true : false;
            var simplexClientId2 = simplexCustomerCheckerResponse5 != null ? simplexCustomerCheckerResponse5.data.client_unique_ref : 0;
            var usr = _unitOfWork.GetRepository<IUserRepository>().GetUserByUserNameAndUserType(Registraion.UserName, Request.UserType);
            var IsPwdExists = usr != null ? _unitOfWork.GetRepository<IUserCredentialsRepository>()
                .GetUserCredentialsByUcidAndUserIdAndUserType
                (usr.ClientUniqueRef, usr.id, usr.UserType) : null;
           // SaveRegistrationAndSession(_unitOfWork, Registraion, session, usr, otp);
            var customerDataNotFromBvn = _unitOfWork.GetRepository<ICustomerDataNotFromBvnRepository>()
                .GetCustomerDataNotFromBvnByPhoneNumberAndEmail(string.IsNullOrEmpty(Request.Email) ?
                  cbaResponse.result.email : Request.Email,
                  string.IsNullOrEmpty(Request.PhoneNumber) ?
                  cbaResponse.result.mobile : Request.PhoneNumber
                  );
            if (customerDataNotFromBvn == null)
            {
                _unitOfWork.GetRepository<ICustomerDataNotFromBvnRepository>().AddCustomerDataNotFromBvn(new CustomerDataNotFromBvn()
                {
                    Address = cbaResponse.result.Address,
                    ChannelId = Request.ChannelId,
                    Email = Request.Email,
                    PhoneNumber = cbaResponse.result.mobile,
                    PhoneNumberNotFromBvn = Request.PhoneNumber
                });
            }
           // SendEmailAndOtp("Otp", OtpType.Registration, _appSettings, Registraion, otp);
            var registrationResponse = new RegistrationResponse
            {
                Email = cbaResponse.result.email,
                PhoneNumber = cbaResponse.result.mobile,
                SessionID = session,
                RequestReference = uniRef,
                IsUsernameExist = usr != null,
                IsAccountNumberExist = true,
                IsPasswordExist = IsPwdExists != null,
                assetcapitalinsuranceregid = Registraion.id,
                hasSimplexAccount = hasSimplexAccount2,
                simplexClientUniqueId = simplexClientId2
            };
            return GenericApiResponse<RegistrationResponse>.SuccessResponse(registrationResponse, CustomerEnumResponse.Successful.GetDescription());
        }
    }
}
