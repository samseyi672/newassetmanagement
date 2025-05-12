

namespace NewAsset.Application.Common.dtos.request
{

    /// <summary>
    /// This contains the common property of dto request
    /// </summary>
    public class GenericRegRequest
    {
        public int ChannelId { get; set; }
        public string Session { get; set; }
        public string RequestReference { get; set; }
    }
}
