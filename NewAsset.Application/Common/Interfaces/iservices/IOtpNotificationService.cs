


namespace NewAsset.Application.Common.Interfaces.iservices
{
    public interface IOtpNotificationService
    {
        //  public void SendOtp(string otp);
        public string generateOtpMessage(OtpType otpType, OtpMessage otpMessage, string Otp, string PhoneNumber);
        public Task SendOtpNotificationToCustomer(string subject, string PhoneNumber, string narration, string alertType, string smsurl);
    }
}
