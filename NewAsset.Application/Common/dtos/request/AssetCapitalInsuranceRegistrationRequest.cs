

namespace NewAsset.Application.Common.dtos.request
{
    public class AssetCapitalInsuranceRegistrationRequest
    {
        public int ChannelId { get; set; }
        public string Bvn { get; set; }
        public string PhoneNumber { get; set; }
        public string Nin { get; set; }
        public string Email { set; get; }
        public string Address { get; set; }
        public string UserType { get; set; }
    }
}
