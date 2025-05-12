

namespace NewAsset.Infrastructure.Persistence.Repositories
{
    /// <summary>
    /// Hybrid UserRepository crud operations unique to user entity
    /// </summary>
    public sealed class UserRepository : GenericRepository<User>,IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(DapperDataContext dapperDataContext, AppDbContext context) : base(dapperDataContext)
        {
          _context=context;
        }

        public void AddUser(User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.id == user.id);
            if (existingUser != null)
            {
                _context.Entry(existingUser).CurrentValues.SetValues(user);
            }
            else
            {
                _context.Users.Add(user); // new entities
            }
            _context.SaveChanges();
        }

        public void DeleteUser(string userName)
        {
            var user = _context.Users
                 .FirstOrDefault(p => string.Equals(p.UserName, userName, StringComparison.CurrentCultureIgnoreCase));
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUserByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public User GetUserByUserNameAndUserType(string userName, string userType)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User registration)
        {
            throw new NotImplementedException();
        }
    }
}




