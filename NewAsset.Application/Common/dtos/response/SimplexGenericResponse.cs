using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAsset.Application.Common.dtos.response
{
    public class SimplexGenericResponse
    {
        public bool hasError { get; set; }
        public string statusCode { get; set; }
        public string message { get; set; }
        // public string data { get; set; }
    }
}
