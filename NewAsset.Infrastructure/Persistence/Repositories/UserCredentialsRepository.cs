

namespace NewAsset.Infrastructure.Persistence.Repositories
{
    public class UserCredentialsRepository: GenericRepository<UserCredentials>, IUserCredentialsRepository
    {

        private readonly AppDbContext _context;
        public UserCredentialsRepository(DapperDataContext dapperDataContext, AppDbContext context) : base(dapperDataContext)
        {
            _context = context;
        }

        public Task<string> AddAsync(UserCredentials entity)
        {
            throw new NotImplementedException();
        }

        public void AddUserCredentials(UserCredentials registration)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserCredentials(int ucid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserCredentials> GetAllUserCredentials()
        {
            throw new NotImplementedException();
        }

        public UserCredentials GetUserCredentialsByUcid(int ucid)
        {
            throw new NotImplementedException();
        }

        public UserCredentials GetUserCredentialsByUcidAndUserIdAndUserType(int uniqueref, long userid, string usertype)
        {
            var UserCredentials = _context.UserCredentials
                 .FirstOrDefault(p => p.ucid==uniqueref&&p.UserId==userid&&string.Equals(p.UserType,usertype,StringComparison.CurrentCultureIgnoreCase));
            return UserCredentials;
        }

        public UserCredentials GetUserCredentialsByUcidAndUserIdAndUserType(int uniqueref, string userid, string usertype)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserCredentials entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(UserCredentials registration)
        {
            throw new NotImplementedException();
        }

        Task<UserCredentials> IGenericRepository<UserCredentials>.GetByIdAsync(string guid, params string[] selectData)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<UserCredentials>> IGenericRepository<UserCredentials>.GetBySpecificColumnAsync(string columnName, string columnValue, params string[] selectData)
        {
            throw new NotImplementedException();
        }
    }
}
