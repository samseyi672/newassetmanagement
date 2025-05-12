


namespace NewAsset.Application.Common.Interfaces.Persistence
{
    public interface IUtilityBillRepository: IGenericRepository<UtilityBill>
    {
        IEnumerable<UtilityBill> GetAllUtilityBill();
        UtilityBill GetUtilityBillByUserNameAndUserType(string userName, string UserType);
        bool AddUtilityBill(UtilityBill UtilityBill);
        void UpdateUtilityBill(Signature UtilityBill);
        bool DeleteUtilityBill(string userName, string UserType);
    }
}
