


namespace NewAsset.Application.Common.Interfaces.Persistence
{
    public interface IRegistrationSessionRepository: IGenericRepository<RegistrationSession>
    {
        IEnumerable<RegistrationSession> GetAllRegistrationSession();
        void AddRegistrationSession(RegistrationSession RegistrationSession);
        void UpdateRegistrationSession(RegistrationSession RegistrationSession);
        void DeleteRegistrationSessionByUserIdOrRegid(long userorregid);
    }
}
