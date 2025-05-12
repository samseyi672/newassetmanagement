

namespace NewAsset.Application.Common.dtos.request
{
    public class SavePasswordRequest : SetRegristationCredential
    {
        public string DeviceId { get; set; }
        public string DeviceName { get; set; }
    }
}
