

namespace NewAsset.Application.Common.Interfaces.Persistence
{
    public interface IUserSessionRepository: IGenericRepository<UserSession>
    {
        IEnumerable<UserSession> GetAllUserSession();
        UserSession GetUserSessionByUcid(int ucid);
        void AddUserSession(UserSession registration);
        void UpdateUserSession(UserSession registration);
        void DeleteUserSession(int ucid);
    }
}
