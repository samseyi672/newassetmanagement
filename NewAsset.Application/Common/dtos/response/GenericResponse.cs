

namespace NewAsset.Application.Common.dtos.response
{
    public class GenericResponse : ICloneable
    {
        public bool Success { get; set; }
        public CustomerEnumResponse Response { get; set; }
        public string ResponseMessage => Response.GetDescription();
        public string Message { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
