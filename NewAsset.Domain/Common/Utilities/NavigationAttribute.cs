using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAsset.Domain.Common.Utilities
{
    public class NavigationAttribute : Attribute
    {
        public Type? AssociatedType { get; }
        public string AssociatedProperty { get; }

        public NavigationAttribute(Type? associatedType, string associatedProperty)
        {
         AssociatedType = associatedType;
        AssociatedProperty = associatedProperty;
        }
    }
}
