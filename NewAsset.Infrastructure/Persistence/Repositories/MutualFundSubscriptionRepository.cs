

namespace NewAsset.Infrastructure.Persistence.Repositories
{
    public class MutualFundSubscriptionRepository : GenericRepository<MutualFundSubscription>, IMutualFundSubscriptionRepository
    {
        private readonly AppDbContext _context;
        public MutualFundSubscriptionRepository(DapperDataContext dapperDataContext, AppDbContext context) : base(dapperDataContext)
        {
            _context = context;
        }

        public bool AddSimplexLiquidationServiceRequest(MutualFundSubscription simplexLiquidationServiceRequest)
        {
            throw new NotImplementedException();
        }

        public List<MutualFundSubscription> GetAllSimplexLiquidationServiceRequestByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public MutualFundSubscription GetSimplexLiquidationServiceRequestByUserNameAndAccountNumberAndReference(string UserName, string AccountNumber, string UserType, string MutualReference, string PartialOrFull)
        {
            throw new NotImplementedException();
        }
    }
}
