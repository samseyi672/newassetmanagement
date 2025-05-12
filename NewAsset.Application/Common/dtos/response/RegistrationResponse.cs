

namespace NewAsset.Application.Common.dtos.response
{
    public class RegistrationResponse
    {
        public string SessionID { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string RequestReference { get; set; }
        public bool IsUsernameExist { set; get; }
        public bool IsPasswordExist { set; get; }
        public bool IsAccountNumberExist { set; get; }
        public long assetcapitalinsuranceregid { set; get; }
        public bool hasSimplexAccount { set; get; }
        public long simplexClientUniqueId { set; get; }
    }
}
