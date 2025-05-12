

namespace NewAsset.Domain.Common.Utilities
{
    public class ForeignKeyAttribute
    {
        public string NameValue { get; set; }
        public ForeignKeyAttribute(string nameValue)
        {
            NameValue = nameValue;
        }
    }
}
