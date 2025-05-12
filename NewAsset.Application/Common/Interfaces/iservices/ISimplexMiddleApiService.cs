using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAsset.Application.Common.Interfaces.iservices
{
    public interface ISimplexMiddleApiService
    {
        public Task<string> GetToken();
        public Task<string> SetAPIToken();
    }
}
