
namespace NewAsset.Infrastructure.Services
{

    /// <summary>
    /// Service class for Asset,Capital and the Insurance subsidiaries
    /// </summary>
    public class AssetCapitlInsuranceRegistrationService : IAssetCapitlInsuranceRegistrationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INinValidationService _ninValidationService;
        private readonly IBackOfficeCustomerChecker _backOfficeCustomerChecker;

        public AssetCapitlInsuranceRegistrationService(IUnitOfWork unitOfWork, INinValidationService ninValidationService, IBackOfficeCustomerChecker backOfficeCustomerChecker)
        {
            _unitOfWork = unitOfWork;
            _ninValidationService = ninValidationService;
            _backOfficeCustomerChecker = backOfficeCustomerChecker;
        }

        public Task<GenericApiResponse<string>> CreatePassword(SavePasswordRequest Request, string UserType)
        {
            throw new NotImplementedException();
        }

        public Task<GenericApiResponse<string>> CreateTransPin(SavePasswordRequest Request, string UserType)
        {
            throw new NotImplementedException();
        }

        public Task<GenericApiResponse<string>> CreateUserName(SetRegristationCredential Request, string UserType)
        {
            throw new NotImplementedException();
        }

        public async Task<GenericApiResponse<RegistrationResponse>> StartRegistration(AssetCapitalInsuranceRegistrationRequest Request)
        {
            try
            {
                string session = new SessionEncripter().EncryptString(new SessionGenerator().GetSession());
                string otp = new OtpGenerator().GenerateOtp();
                // Generate unique reference
                string uniRef = $"Reg{new Random().Next(11111, 99999)}{DateTime.UtcNow:ddMMyyyyHHmm}";
                Request.ChannelId = Request.ChannelId == 0 ? 1 : Request.ChannelId;
                // Validate NIN if provided
                if (!string.IsNullOrEmpty(Request.Nin))
                {
                    var response = await _ninValidationService.ValidateNinAsync(Request.Nin, Request.Bvn);
                    if(!response.Success)
                    {
                        return GenericApiResponse<RegistrationResponse>.FailureResponse(CustomerEnumResponse.InvalidNin.GetDescription());
                    }
                }
                // Check if the registration already exists
                // var existingRegistration = (await con.QueryAsync<AssetCapitalInsuranceRegistration>("SELECT * FROM asset_capital_insurance_registration WHERE bvn = @Bvn and user_type=@UserType", new { Bvn = Request.Bvn, UserType = Request.UserType })).FirstOrDefault();
                var existingRegistration = _unitOfWork.GetRepository<IRegistrationRepository>().GetRegistrationByBvnAndUserType(Request.Bvn,Request.UserType);
                if (existingRegistration!=null)
                {
                   var IsCustomerExist= await _backOfficeCustomerChecker.IsCustomerExistInBackOffice(Request.Email,Request.UserType);
                    if(!IsCustomerExist.Success)
                    {
                     return GenericApiResponse<RegistrationResponse>.FailureResponse(CustomerEnumResponse.CustomerValidationUnSuccessful.GetDescription());
                    }
                    var user = _unitOfWork.GetRepository<IUserRepository>().GetUserByUserNameAndUserType(existingRegistration.UserName, existingRegistration.UserType);
                    //save opt
                    _unitOfWork.GetRepository<IRegistrationOtpSessionRepository>().AddRegistrationSession(new RegistrationOtpSession()
                    {
                        bvn = existingRegistration.Bvn,
                        createdAt = DateTime.UtcNow,
                        Otp=otp,
                        OtpType= (int)OtpType.Registration,
                        Session=session,
                        UserType=existingRegistration.UserType
                    }) ;
                    //save session
                    _unitOfWork.GetRepository<IRegistrationSessionRepository>().AddRegistrationSession(new RegistrationSession()
                    {
                       UserType=existingRegistration.UserType,
                       Session=session,
                       ChannelId=1,
                       CreatedOn=DateTime.Now,
                       RegId=1,
                       UserId=user.id                  
                    });
                    //send otp to customer
                }

                return GenericApiResponse<RegistrationResponse>.FailureResponse(KycEnumResponse.WrongUserType.GetDescription());
            }
            catch (Exception ex)
            {
                return GenericApiResponse<RegistrationResponse>.FailureResponse($"Exception: {ex.Message}");
            }
        }


        public Task<GenericApiResponse<string>> ValidateUserName(string username, string UserType)
        {
            throw new NotImplementedException();
        }
    }
}
