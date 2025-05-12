


namespace NewAsset.Application.Common.Interfaces.Persistence
{
    public interface ISimplexLiquidationServiceRequestRepository : IGenericRepository<SimplexLiquidationServiceRequest>
    {
        List<SimplexLiquidationServiceRequest> GetAllSimplexLiquidationServiceRequestByUserName(string userName);
        SimplexLiquidationServiceRequest GetSimplexLiquidationServiceRequestByUserNameAndAccountNumberAndReference(string UserName, string AccountNumber, string UserType, string MutualReference, string PartialOrFull);
        bool AddSimplexLiquidationServiceRequest(SimplexLiquidationServiceRequest simplexLiquidationServiceRequest);
    }
}
