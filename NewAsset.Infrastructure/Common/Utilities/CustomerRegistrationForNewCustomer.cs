

namespace NewAsset.Infrastructure.Common.Utilities
{
    public class CustomerRegistrationForNewCustomer
    {
        public static async Task<GenericApiResponse<RegistrationResponse>> ProcessRegistrationForNewCustomer(Registration Registraion, string uniRef,string session,BvnResp cbaResponse, IBackOfficeCustomerChecker _backOfficeCustomerChecker,IUnitOfWork _unitOfWork,AssetCapitalInsuranceRegistrationRequest Request)
        {
            var IsCustomerExist = await _backOfficeCustomerChecker.IsCustomerExistInBackOffice(Request.Email, Request.UserType);
            if (!IsCustomerExist.Success)
            {
                return GenericApiResponse<RegistrationResponse>.FailureResponse(CustomerEnumResponse.CustomerValidationUnSuccessful.GetDescription());
            }
            _unitOfWork.GetRepository<IRegistrationRepository>().AddRegistration(new Registration()
            {
                LastName = cbaResponse.Lastname,
                phoneNumber = cbaResponse.PhoneNumber,
                email = cbaResponse.Email,
                FirstName = cbaResponse.Firstname,
                UserType = Request.UserType
            });
            SimplexCustomerCheckerResponse simplexCustomerCheckerResponse2 = JsonConvert.DeserializeObject<SimplexCustomerCheckerResponse>(JsonConvert.SerializeObject(IsCustomerExist?.Data));
            var hasSimplexAccount = simplexCustomerCheckerResponse2 != null ? true : false;
            var simplexClientId = simplexCustomerCheckerResponse2 != null ? simplexCustomerCheckerResponse2.data.client_unique_ref : 0;
            var response = new RegistrationResponse
            {
                Email = cbaResponse.Email,
                PhoneNumber = cbaResponse.PhoneNumber,
                SessionID = session,
                RequestReference = uniRef,
                IsUsernameExist = false,
                IsAccountNumberExist = false,
                IsPasswordExist = false,
                assetcapitalinsuranceregid = Registraion.id,
                hasSimplexAccount = hasSimplexAccount,
                simplexClientUniqueId = simplexClientId
            };
            return GenericApiResponse<RegistrationResponse>.SuccessResponse(response, CustomerEnumResponse.Successful.GetDescription());
        }
    }
}
