
namespace NewAsset.Application.Common.Interfaces.Persistence
{

    /// <summary>
    /// This is for operations that are unique to user entity
    /// </summary>
    public interface IUserRepository:IGenericRepository<User>
    {
        IEnumerable<User> GetAllUsers();
        User GetUserByUserName(string userName);
        void AddUser(User registration);
        void UpdateUser(User registration);
        void DeleteUser(string userName);
        User GetUserByUserNameAndUserType(string userName, string userType);
    }
}
