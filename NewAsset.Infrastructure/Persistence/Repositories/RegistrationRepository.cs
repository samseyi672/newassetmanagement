using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAsset.Infrastructure.Persistence.Repositories
{
    internal class RegistrationRepository : GenericRepository<Registration>,IRegistrationRepository
    {
        private readonly AppDbContext _context;
        public RegistrationRepository(DapperDataContext dapperDataContext, AppDbContext context) : base(dapperDataContext)
        {
            _context = context;
        }
        public void AddRegistration(Registration registration)
        {
            var existingRegistration = _context.Registration.FirstOrDefault(u => u.Id == registration.Id);
            if (existingRegistration != null)
            {
                _context.Entry(existingRegistration).CurrentValues.SetValues(registration);
            }
            else
            {
                _context.Registration.Add(registration); // new entities
            }
            _context.SaveChanges();
        }

        public IEnumerable<Registration> GetAllRegistration()
        {
            return _context.Registration;
        }

        public Registration GetRegistrationByBvnAndUserType(string bvn, string UserType)
        {
            return _context.Registration
              .FirstOrDefault(registration => string.Equals(registration.Bvn,bvn, StringComparison.CurrentCultureIgnoreCase)&&
                string.Equals(registration.UserType,UserType,StringComparison.CurrentCultureIgnoreCase));
        }

        public Registration GetRegistrationByReference(string reference)
        {
            return _context.Registration
            .FirstOrDefault(registration => registration.RequestReference==reference);
        }

        public Registration GetRegistrationByUserNameAndUserType(string userName, string userType)
        {
          return _context.Registration
        .FirstOrDefault(registration => string.Equals(registration.UserName,userType, StringComparison.CurrentCultureIgnoreCase) &&
          string.Equals(registration.UserName, userType, StringComparison.CurrentCultureIgnoreCase));
        }

    }
}
