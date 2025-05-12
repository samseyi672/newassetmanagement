

namespace NewAsset.Application.Common.Interfaces.Persistence
{
    public interface IMobileDeviceRepository: IGenericRepository<MobileDevice>
    {
        IEnumerable<MobileDevice> GetAllMobileDevice();
        MobileDevice GetMobileDeviceByUserId(long userid);
        void AddMobileDevice(MobileDevice registration);
        void UpdateMobileDevice(MobileDevice registration);
        void DeleteMobileDevice(long userid);
    }
}
