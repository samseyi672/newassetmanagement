using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAsset.Infrastructure.Common.Utilities
{
    public class CustomerRegistrationForInCompleteRegistration
    {
        public static async Task<GenericApiResponse<RegistrationResponse>> processRegistrationForExistingCustomer(IBackOfficeCustomerChecker _backOfficeCustomerChecker, IUnitOfWork _unitOfWork, Registration existingRegistration, string session, string otp, AssetCapitalInsuranceRegistrationRequest Request, FinedgeSearchBvn accountCheck)
        {
            var IsCustomerExist = await _backOfficeCustomerChecker.IsCustomerExistInBackOffice(Request.Email, Request.UserType);
            if (!IsCustomerExist.Success)
            {
                return GenericApiResponse<RegistrationResponse>.FailureResponse(CustomerEnumResponse.CustomerValidationUnSuccessful.GetDescription());
            }
            var user = _unitOfWork.GetRepository<IUserRepository>().GetUserByUserNameAndUserType(existingRegistration.UserName, existingRegistration.UserType);
            //save opt
            if (user != null)
            {
               // SaveRegistrationAndSession(_unitOfWork, existingRegistration, session, user, otp);
                //send otp and email to customer
               // SendEmailAndOtp("Otp", OtpType.Registration, _appSettings, existingRegistration, otp);
            }
            SimplexCustomerCheckerResponse simplexCustomerCheckerResponse4 = JsonConvert.DeserializeObject<SimplexCustomerCheckerResponse>(JsonConvert.SerializeObject(IsCustomerExist.Data));
            var hasSimplexAccount4 = simplexCustomerCheckerResponse4 != null ? true : false;
            var simplexClientId4 = simplexCustomerCheckerResponse4 != null ? simplexCustomerCheckerResponse4.data.client_unique_ref : 0;
            var passwordCheck = user != null
                ? _unitOfWork.GetRepository<IUserCredentialsRepository>().GetUserCredentialsByUcidAndUserIdAndUserType(user.ClientUniqueRef, user.id, Request.UserType).credential
                : null;
            var regisrationReponse = new RegistrationResponse
            {
                Email = existingRegistration.email,
                PhoneNumber = existingRegistration.phoneNumber,
                SessionID = session,
                RequestReference = existingRegistration.RequestReference,
                IsUsernameExist = user != null,
                IsAccountNumberExist = accountCheck?.success ?? false,
                IsPasswordExist = passwordCheck != null,
                assetcapitalinsuranceregid = existingRegistration.id,
                hasSimplexAccount = hasSimplexAccount4,
                simplexClientUniqueId = simplexClientId4
            };
            return GenericApiResponse<RegistrationResponse>.SuccessResponse(regisrationReponse, CustomerEnumResponse.Successful.GetDescription());
        }
    }
}
