using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAsset.Domain.Common.Utilities
{


    /// <summary>
    /// To allow reflection-based mapping on entity when using
    /// dapper dynamic query 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnNameAttribute:Attribute
    {
       public string NameValue { get; set; }
        public ColumnNameAttribute(string nameValue)
        {
          NameValue = nameValue;
        }
    }
}
