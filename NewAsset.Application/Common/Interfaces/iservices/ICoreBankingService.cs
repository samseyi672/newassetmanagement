

namespace NewAsset.Application.Common.Interfaces.iservices
{

    /// <summary>
    ///  This is a service to check for Core Banking Data
    /// </summary>
    public interface ICoreBankingService
    {
        public Task<FinedgeSearchBvn> AssetCapitalInsuranceCheckCbaByBvn(String Bvn);
        Task<ValidateBvn> ValidateAssetCapitalInsuranceBvn(string Bvn, IUnitOfWork unitOfWork);
    }
}
