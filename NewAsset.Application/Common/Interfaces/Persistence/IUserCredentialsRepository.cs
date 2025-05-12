using NewAsset.Domain.UserCredentials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAsset.Application.Common.Interfaces.Persistence
{
    public interface IUserCredentialsRepository : IGenericRepository<UserCredentials>
    {
        IEnumerable<UserCredentials> GetAllUserCredentials();
        UserCredentials GetUserCredentialsByUcid(int ucid);
        void AddUserCredentials(UserCredentials registration);
        void UpdateUser(UserCredentials registration);
        void DeleteUserCredentials(int ucid);
    }
}
