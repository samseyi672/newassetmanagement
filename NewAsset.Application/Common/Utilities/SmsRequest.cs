
using System.ComponentModel.DataAnnotations;

namespace NewAsset.Application.Common.Utilities
{
    public class SmsRequest
    {
        [Required(ErrorMessage = "message cannot be empty")]
        public string message { get; set; }

        [Required(ErrorMessage = "alertType cannot be empty")]
        public string alertType { get; set; }

        [Required(ErrorMessage = "subject cannot be empty")]
        public string subject { get; set; }

        [Required(ErrorMessage = "contactList cannot be empty")]
        public List<string> contactList { get; set; }

        public SmsRequest()
        {
            contactList = new List<string>();
        }
    }

}
