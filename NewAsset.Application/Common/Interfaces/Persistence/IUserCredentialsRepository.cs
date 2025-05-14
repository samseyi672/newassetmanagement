using NewAsset.Domain.UserCredentials.Models;


namespace NewAsset.Application.Common.Interfaces.Persistence
{
    public interface IUserCredentialsRepository : IGenericRepository<UserCredentials>
    {
        IEnumerable<UserCredentials> GetAllUserCredentials();
        UserCredentials GetUserCredentialsByUcid(int ucid);
        void AddUserCredentials(UserCredentials registration);
        void UpdateUser(UserCredentials registration);
        void DeleteUserCredentials(int ucid);
        UserCredentials GetUserCredentialsByUcidAndUserIdAndUserType(long uniqueref,long userid, string usertype);
    }
}
