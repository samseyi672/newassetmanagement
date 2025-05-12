using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAsset.Application.Common.dtos.response
{
    public class SimplexCustomerCheckerResponse : SimplexGenericResponse
    {
        public SimplexCustomerCheckerData data { get; set; }
    }
    public class SimplexCustomerCheckerData
    {
        public int client_unique_ref { set; get; }
        public bool exists { set; get; }
    }
}
