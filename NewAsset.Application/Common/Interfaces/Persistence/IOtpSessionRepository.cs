


namespace NewAsset.Application.Common.Interfaces.Persistence
{
    public interface IOtpSessionRepository: IGenericRepository<OtpSession>
    {
        IEnumerable<OtpSession> GetAllOtpSession();
        OtpSession GetOtpSessionByUserName(int ucid);
        void AddOtpSession(OtpSession OtpSession);
        void UpdateOtpSession(OtpSession OtpSession);
        void DeleteOtpSession(int ucid);
    }
}
