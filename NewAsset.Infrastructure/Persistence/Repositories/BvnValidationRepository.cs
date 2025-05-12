

namespace NewAsset.Infrastructure.Persistence.Repositories
{
    public sealed class BvnValidationRepository : GenericRepository<BvnValidation>, IBvnValidationRepository
    {
        private readonly AppDbContext _context;
        public BvnValidationRepository(DapperDataContext dapperDataContext, AppDbContext context) : base(dapperDataContext)
        {
            _context = context;
        }
        public bool AddBvnValidation(BvnValidation bvnValidation)
        {
            throw new NotImplementedException();
        }

        public BvnValidation GetBvnValidationByBvn(string Bvn)
        {
            var existingBvnValidation = _context.BvnValidations.FirstOrDefault(u => u.BVN.Equals(Bvn,
            StringComparison.CurrentCultureIgnoreCase));
            return existingBvnValidation;
        }
    }
}
