

namespace NewAsset.Application.Common.Utilities
{
    public class OtpGenerator
    {
        public string GenerateOtp() => appSetting.DemoOtp == "y" ? "123456" : new Random().Next(111111, 999999).ToString();
    }
}
