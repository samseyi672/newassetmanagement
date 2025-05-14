



namespace NewAsset.Application.Common.Interfaces.Persistence
{
    public interface IRegistrationRepository: IGenericRepository<Registration>
    {
        IEnumerable<Registration> GetAllRegistration();
        Registration GetRegistrationByBvnAndUserType(string bvn, string UserType);
        void AddRegistration(Registration registration);
        Registration GetRegistrationByUserNameAndUserType(string userName, string userType);
        Registration GetRegistrationByReference(string reference);
    }
}
