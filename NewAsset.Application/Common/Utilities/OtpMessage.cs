

namespace NewAsset.Application.Common.Utilities
{
    public class OtpMessage
    {
        public string Registration { get; set; }
        public  string PasswordReset { get; set; }
        public  string UnlockDevice { get; set; }
        public  string UnlockProfile { get; set; }
        public string Confirmation { get; set; }
        public string PinResetOrChange { get; set; }
        public string RetrieveUsername { get; set; }
    }
}
