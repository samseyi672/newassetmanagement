


namespace NewAsset.Application.Common.Interfaces.Persistence
{
    public interface IMutualFundSubscriptionRepository: IGenericRepository<MutualFundSubscription>
    {
        List<MutualFundSubscription> GetAllSimplexLiquidationServiceRequestByUserName(string userName);
        MutualFundSubscription GetSimplexLiquidationServiceRequestByUserNameAndAccountNumberAndReference(string UserName, string AccountNumber, string UserType, string MutualReference, string PartialOrFull);
        bool AddSimplexLiquidationServiceRequest(MutualFundSubscription simplexLiquidationServiceRequest);
    }
}
