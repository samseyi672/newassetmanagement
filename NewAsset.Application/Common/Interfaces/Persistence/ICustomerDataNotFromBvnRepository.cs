

namespace NewAsset.Application.Common.Interfaces.Persistence
{
    public interface ICustomerDataNotFromBvnRepository: IGenericRepository<CustomerDataNotFromBvn>
    {
        IEnumerable<CustomerDataNotFromBvn> GetAllCustomerDataNotFromBvn();
        CustomerDataNotFromBvn GetCustomerDataNotFromBvnByUserName(string userName);
        CustomerDataNotFromBvn GetUserByCustomerDataNotFromBvnPhoneNumber(string PhoneNumber);
        void AddCustomerDataNotFromBvn(CustomerDataNotFromBvn CustomerDataNotFromBvn);
        void UpdateOCustomerDataNotFromBvn(CustomerDataNotFromBvn CustomerDataNotFromBvn);
        void DeleteCustomerDataNotFromBvn(string userName);
        CustomerDataNotFromBvn GetCustomerDataNotFromBvnByUserIdAndUserType(long UserId, string userType);
    }
}
