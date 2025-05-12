

namespace NewAsset.Application.Common.Interfaces.Persistence
{
    public interface IBvnValidationRepository: IGenericRepository<BvnValidation>
    {
        BvnValidation GetBvnValidationByBvn(string Bvn);
        bool AddBvnValidation(BvnValidation bvnValidation);
    }
}
