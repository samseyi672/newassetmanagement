
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
        private readonly AppSettings _appSettings;
        private readonly IOtpNotificationService _notificationService;
        private readonly IEmailNotificationService _emailNotificationService;
        private readonly ITemplateService _templateService;
        private readonly ICoreBankingService _coreBankingService;

        public AssetCapitlInsuranceRegistrationService(ICoreBankingService coreBankingService,ITemplateService templateService,IEmailNotificationService emailNotificationService,IOtpNotificationService otpNotificationService,IUnitOfWork unitOfWork, INinValidationService ninValidationService, IBackOfficeCustomerChecker backOfficeCustomerChecker,IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            _ninValidationService = ninValidationService;
            _backOfficeCustomerChecker = backOfficeCustomerChecker;
            _appSettings = appSettings.Value;
            _ninValidationService= ninValidationService;
            _emailNotificationService = emailNotificationService;
            _templateService = templateService;
            _coreBankingService = coreBankingService;
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
                var cbaResponse = await _coreBankingService.AssetCapitalInsuranceCheckCbaByBvn(Request.Bvn);
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
                var existingRegistration = _unitOfWork.GetRepository<IRegistrationRepository>().GetRegistrationByBvnAndUserType(Request.Bvn,Request.UserType);
                if (existingRegistration!=null)
                {
                    //save opt
                    var response =  await CustomerRegistrationForInCompleteRegistration.processRegistrationForExistingCustomer(_backOfficeCustomerChecker,_unitOfWork,existingRegistration,session,otp,Request,cbaResponse);
                    if(response!=null && response.Success)
                    {
                        var user = _unitOfWork.GetRepository<IUserRepository>().GetUserByUserNameAndUserType(existingRegistration.UserName, Request.UserType);
                        SaveRegistrationAndSession(_unitOfWork, existingRegistration, session, user, otp);
                        //send otp and email to customer
                        SendEmailAndOtp("Otp", OtpType.Registration, _appSettings, existingRegistration, otp);
                    }
                }
                // process new registration for customers that exists in core banking
                _unitOfWork.GetRepository<IRegistrationRepository>().AddRegistration(new Registration()
                {
                  Address=Request.Address,
                  Bvn=Request.Bvn,
                  Channelid=Request.ChannelId,
                  Nin=Request.Nin,
                  UserType=Request.UserType,
                  RequestReference=uniRef
                });
                var Registraion = _unitOfWork.GetRepository<IRegistrationRepository>().GetRegistrationByBvnAndUserType(Request.Bvn,Request.UserType);
                if(cbaResponse!=null) //if customer exists in cba
                {
                    var response =  await CustomerRegistrationInCoreBanking.processRegistrationForExistingCustomerInCoreBanking(_backOfficeCustomerChecker,_coreBankingService,cbaResponse,_unitOfWork,Registraion,session,otp,Request,uniRef);
                    if(response.Success)
                    {
                        var user = _unitOfWork.GetRepository<IUserRepository>().GetUserByUserNameAndUserType(Registraion.UserName, Request.UserType);
                        SaveRegistrationAndSession(_unitOfWork, existingRegistration, session, user, otp);
                        //send otp and email to customer
                        SendEmailAndOtp("Otp", OtpType.Registration, _appSettings, existingRegistration, otp);
                    }
                    return response;
                }
                //process registration for new customers entirely
                //Validate Bvn if no Cba data is found
                var bvnDetail2 = await _coreBankingService.ValidateAssetCapitalInsuranceBvn(Request.Bvn, _unitOfWork);
                if (!bvnDetail2.Success)
                {
                    GenericApiResponse<RegistrationResponse>.FailureResponse(CustomerEnumResponse.InvalidBvn.GetDescription());
                }
               var BvnResp = bvnDetail2.BvnDetails;
                var RegResponse = await CustomerRegistrationForNewCustomer.ProcessRegistrationForNewCustomer(Registraion,uniRef,session,
                    BvnResp, _backOfficeCustomerChecker,_unitOfWork,Request);
                if (RegResponse.Success)
                {
                    var user = _unitOfWork.GetRepository<IUserRepository>().GetUserByUserNameAndUserType(Registraion.UserName,Request.UserType);
                    SaveRegistrationAndSession(_unitOfWork, existingRegistration, session, user, otp);
                    //send otp and email to customer
                    SendEmailAndOtp("Otp", OtpType.Registration, _appSettings, existingRegistration, otp);
                }
                return RegResponse;
            }
            catch (Exception ex)
            {
                return GenericApiResponse<RegistrationResponse>.FailureResponse($"Exception: {ex.Message}");
            }
        }
        private void SaveRegistrationAndSession(IUnitOfWork unitOfWork,Registration registration,string session,User user,string otp)
        {
            _unitOfWork.GetRepository<IRegistrationOtpSessionRepository>().AddRegistrationSession(new RegistrationOtpSession()
            {
                bvn = registration.Bvn,
                createdAt = DateTime.UtcNow,
                Otp = otp,
                OtpType = (int)OtpType.Registration,
                Session = session,
                UserType = registration.UserType
            });
            //save registration session
            _unitOfWork.GetRepository<IRegistrationSessionRepository>().AddRegistrationSession(new RegistrationSession()
            {
                UserType = registration.UserType,
                Session = session,
                ChannelId = 1,
                CreatedOn = DateTime.Now,
                RegId = 1,
                UserId = user.id
            });
        }
        private async Task SendEmailAndOtp(string subject,OtpType otpType,AppSettings settings,Registration registration,string otp)
        {
            Task.Run(async () =>
            {
                OtpMessage otpMessage = new OtpMessage();
                otpMessage.Registration = "Registration";
                string message = _notificationService.generateOtpMessage(OtpType.Registration, otpMessage, otp, registration.phoneNumber);
                _notificationService.SendOtpNotificationToCustomer("Otp", registration.phoneNumber, message, otpMessage.Registration, _appSettings.SmsUrl);
                SendMail sender = new SendMail();
                var data = new
                {
                  email=registration.email,
                  otp=otp
                };
                string filepath = Path.Combine(_appSettings.PartialViews, "paymentnotificationoutsideflutterwave.html");
                sender.Html = _templateService.RenderScribanTemplate(filepath, data);
                _emailNotificationService.sendOtpMail(sender,null);
            });
        }
        public Task<GenericApiResponse<string>> ValidateUserName(string username, string UserType)
        {
            throw new NotImplementedException();
        }

        public Task<GenericApiResponse<RegistrationResponse>> GetByReferenceAsync(string reference)
        {
            var repo = _unitOfWork.GetRepository<IRegistrationRepository>();
            var registration = repo.GetRegistrationByReference(reference);

            if (registration == null)
                return Task.FromResult(GenericApiResponse<RegistrationResponse>.FailureResponse(
                    CustomerEnumResponse.RegistratioNotFound.GetDescription()));

            var response = new RegistrationResponse
            {
                Email = registration.email,
                PhoneNumber = registration.phoneNumber,
                RequestReference = registration.RequestReference
            };
            return Task.FromResult(GenericApiResponse<RegistrationResponse>.SuccessResponse(response));
        }


    }
}


































