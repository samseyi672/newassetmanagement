


namespace NewAsset.Application.Common.Interfaces.Persistence
{
    public interface ICustomerDeviceRepository:IGenericRepository<CustomerDevice>
    {
        IEnumerable<CustomerDevice> GetAllCustomerDevice();
        CustomerDevice GetCustomerDeviceByUserName(string userName);
        void AddCustomerDevice(CustomerDevice registration);
        void UpdateCustomerDevice(CustomerDevice registration);
        void DeleteCustomerDevice(string userName);
    }
}
