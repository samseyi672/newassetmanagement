

namespace NewAsset.Application.Common.Interfaces.Persistence
{
    public interface IRegistrationOtpSessionRepository: IGenericRepository<RegistrationOtpSession>
    {
        IEnumerable<RegistrationOtpSession> GetAllRegistrationSession();
        void AddRegistrationSession(RegistrationOtpSession RegistrationOtpSession);
      //  RegistrationOtpSession GetRegistrationOtpSessionByUserNameAndUserType(string UserName,string UserType);
    }
}
