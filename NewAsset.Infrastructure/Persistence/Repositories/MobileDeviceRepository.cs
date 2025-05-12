

namespace NewAsset.Infrastructure.Persistence.Repositories
{
    public class MobileDeviceRepository : GenericRepository<MobileDevice>, IMobileDeviceRepository
    {

        private readonly AppDbContext _context;
        public MobileDeviceRepository(DapperDataContext dapperDataContext, AppDbContext context) : base(dapperDataContext)
        {
            _context = context;
        }
        public void AddMobileDevice(MobileDevice registration)
        {
            var existingMobileDevice = _context.MobileDevice.FirstOrDefault(u => u.id == registration.id);
            if (existingMobileDevice != null)
            {
                _context.Entry(existingMobileDevice).CurrentValues.SetValues(registration);
            }
            else
            {
                _context.MobileDevice.Add(registration); // new entities
            }
            _context.SaveChanges();
        }

        public void DeleteMobileDevice(long userid)
        {
            var user = _context.MobileDevice
              .FirstOrDefault(p => p.UserId == userid);
            if (user != null)
            {
                _context.MobileDevice.Remove(user);
                _context.SaveChanges();
            }
        }

        public IEnumerable<MobileDevice> GetAllMobileDevice()
        {
            return _context.MobileDevice;
        }

        public MobileDevice GetMobileDeviceByUserId(long userid)
        {
            return _context.MobileDevice.FirstOrDefault(p => p.UserId == userid);
        }

        public void UpdateMobileDevice(MobileDevice registration)
        {
            _context.MobileDevice.Update(registration);
            _context.SaveChanges();
        }
    }
}
