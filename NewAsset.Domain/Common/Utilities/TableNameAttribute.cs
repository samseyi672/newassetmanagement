

namespace NewAsset.Domain.Common.Utilities
{
     //for custom atributes
     [AttributeUsage(AttributeTargets.Class)]
    public class TableNameAttribute:Attribute
    {
        public string NameValue { get; set; }

        public TableNameAttribute(string nameValue)
        {
            NameValue = nameValue;
        }
    }
}
