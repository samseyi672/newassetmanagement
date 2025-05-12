

namespace NewAsset.Infrastructure.Persistence.Repositories
{
    public class CustomerDeviceRepository : GenericRepository<CustomerDevice>, ICustomerDeviceRepository
    {

        private readonly AppDbContext _context;
        public CustomerDeviceRepository(DapperDataContext dapperDataContext, AppDbContext context) : base(dapperDataContext)
        {
            _context = context;
        }
        public void AddCustomerDevice(CustomerDevice registration)
        {
            _context.CustomerDevice.Add(registration);
            _context.SaveChanges();
        }

        public void DeleteCustomerDevice(string userName)
        {
            var user = _context.CustomerDevice
               .FirstOrDefault(p => string.Equals(p.UserName, userName, StringComparison.CurrentCultureIgnoreCase));
            if (user != null)
            {
                _context.CustomerDevice.Remove(user);
                _context.SaveChanges();
            }
        }

        public IEnumerable<CustomerDevice> GetAllCustomerDevice()
        {
            return _context.CustomerDevice;
        }

        public CustomerDevice GetCustomerDeviceByUserName(string userName)
        {
            return _context.CustomerDevice
                 .FirstOrDefault(p => string.Equals(p.UserName, userName, StringComparison.CurrentCultureIgnoreCase));
        }

        public void UpdateCustomerDevice(CustomerDevice registration)
        {
            _context.CustomerDevice.Update(registration);
            _context.SaveChanges();
        }
    }
}
