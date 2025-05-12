

namespace NewAsset.Infrastructure.Persistence.Repositories
{
    public class OtpSessionRepository : GenericRepository<OtpSession>,IOtpSessionRepository
    {

        private readonly AppDbContext _context;
        public OtpSessionRepository(DapperDataContext dapperDataContext, AppDbContext context) : base(dapperDataContext)
        {
            _context = context;
        }
        public void AddOtpSession(OtpSession OtpSession)
        {
            // _context.OtpSession.Add(OtpSession);
            // _context.SaveChanges();
            var existingOtpSession = _context.OtpSession.FirstOrDefault(u => u.Id == OtpSession.Id);
            if (existingOtpSession != null)
            {
                _context.Entry(existingOtpSession).CurrentValues.SetValues(OtpSession);
            }
            else
            {
                _context.OtpSession.Add(OtpSession); // new entities
            }
            _context.SaveChanges();
        }

        public void DeleteOtpSession(int ucid)
        {
            var user = _context.OtpSession
                .FirstOrDefault(p => p.ucid == ucid);
            if (user != null)
            {
                _context.OtpSession.Remove(user);
                _context.SaveChanges();
            }
        }

        public IEnumerable<OtpSession> GetAllOtpSession()
        {
            return _context.OtpSession;
        }

        public OtpSession GetOtpSessionByUserName(int ucid)
        {
            return _context.OtpSession.FirstOrDefault(p => p.ucid == ucid);
        }

        public void UpdateOtpSession(OtpSession OtpSession)
        {
            _context.OtpSession.Update(OtpSession);
            _context.SaveChanges();
        }
    }
}
