
namespace NewAsset.Infrastructure.Persistence.Repositories
{
    public class RegistrationOtpSessionRepository:GenericRepository<RegistrationOtpSession>, IRegistrationOtpSessionRepository
    {
        private readonly AppDbContext _context;
    public RegistrationOtpSessionRepository(DapperDataContext dapperDataContext, AppDbContext context) : base(dapperDataContext)
    {
        _context = context;
    }

        public void AddRegistrationSession(RegistrationOtpSession RegistrationOtpSession)
        {
            var existingUser = _context.RegistrationOtpSession.FirstOrDefault(u => u.Session == RegistrationOtpSession.Session);
            if (existingUser != null)
            {
                 existingUser.Session = RegistrationOtpSession.Session;
                _context.Entry(existingUser).CurrentValues.SetValues(RegistrationOtpSession);
            }
            else
            {
                _context.RegistrationOtpSession.Add(RegistrationOtpSession); // new entities
            }
            _context.SaveChanges();
        }

        public IEnumerable<RegistrationOtpSession> GetAllRegistrationSession()
        {
            throw new NotImplementedException();
        }
    }
}
