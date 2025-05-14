

namespace NewAsset.Infrastructure.Services
{
    public class OtpNotificationService : IOtpNotificationService
    {
        private readonly ILogger<NinValidationService> _logger;
        private readonly IHttpService _httpService;

        public OtpNotificationService(ILogger<NinValidationService> logger, IHttpService httpService)
        {
            _logger = logger;
            _httpService = httpService;
        }
        public string generateOtpMessage(OtpType otpType, OtpMessage otpMessage,string Otp,string PhoneNumber)
        {
            _logger.LogInformation("sending otp " + Otp);
            string msg = null;
            _logger.LogInformation("sending otp number ....." + PhoneNumber);
            PhoneNumber = PhoneNumber.Replace(PhoneNumber, "234");
            _logger.LogInformation("number " + PhoneNumber);
            if (otpType == OtpType.PasswordReset)
                msg = otpMessage.PasswordReset;

            if (otpType == OtpType.UnlockDevice)
                msg = otpMessage.UnlockDevice;

            if (otpType == OtpType.UnlockProfile)
                msg = otpMessage.UnlockProfile;

            if (otpType == OtpType.Registration)
                msg = otpMessage.Registration;

            if (otpType == OtpType.Confirmation)
                msg = otpMessage.Confirmation;

            if (otpType == OtpType.PinResetOrChange)
                msg = otpMessage.PinResetOrChange;

            if (otpType == OtpType.RetrieveUsername)
                msg = otpMessage.RetrieveUsername;

            msg = msg.Replace("$otp", Otp);
            return msg;
        }

        public async Task SendOtpNotificationToCustomer(string subject, string PhoneNumber, string narration, string alertType, string smsurl)
        {
            try
            {
                SmsRequest smsRequest = new SmsRequest();
                smsRequest.message = narration;
                smsRequest.subject = subject;
                smsRequest.alertType = alertType;
                smsRequest.contactList.Add(PhoneNumber);
                string SmsResponse = await _httpService.CallServiceAsyncToString(Method.POST, smsurl, smsRequest, true);
               // Console.WriteLine($"SmsResponse {SmsResponse}");
                _logger.LogInformation($"SmsResponse {SmsResponse}");
            }
            catch (Exception ex)
            {
                throw new NetworkRequestException("Sms service is not available .....");
            }
        }
    }
}
