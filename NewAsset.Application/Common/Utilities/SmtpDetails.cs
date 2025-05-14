

namespace NewAsset.Application.Common.Utilities
{
    public class SmtpDetails
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FrmMail { get; set; }
        public string FrmName { get; set; }
        public string BccMail { get; set; }
        public string EmailTemplate { get; set; }
        public string WelcomeHtml { get; set; }
        public string UpdateProfileHtml { get; set; }
        public string NonActivityHtml { get; set; }
        public string NewUserHtml { get; set; }
        public string ProfileVisitHtml { get; set; }
        public string ForgotPassword { get; set; }
    }
}
