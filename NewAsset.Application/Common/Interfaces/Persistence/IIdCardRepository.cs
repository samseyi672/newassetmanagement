


namespace NewAsset.Application.Common.Interfaces.Persistence
{
    public interface IIdCardRepository: IGenericRepository<IdCard>
    {
        IEnumerable<IdCard> GetAllIdCard();
        IdCard GetIdCardByUserNameAndUserType(string userName, string UserType);
        bool AddIdCard(IdCard IdCard);
        void UpdateIdCard(IdCard IdCard);
        bool DeleteIdCard(string userName, string UserType);
    }
}
