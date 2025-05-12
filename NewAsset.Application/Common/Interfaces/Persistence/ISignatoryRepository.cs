


namespace NewAsset.Application.Common.Interfaces.Persistence
{
    public interface ISignatoryRepository: IGenericRepository<Signature>
    {
        IEnumerable<Signature> GetAllSignature();
        Signature GetSignatureByUserNameAndUserType(string userName, string UserType);
        bool AddSignature(Signature Signature);
        void UpdateSignature(Signature Signature);
        bool DeleteSignature(string userName, string UserType);
    }
}
