

namespace NewAsset.Infrastructure.Persistence.Repositories
{
    public class IdCardRepository : GenericRepository<IdCard>,IIdCardRepository
    {

        private readonly AppDbContext _context;
        public IdCardRepository(DapperDataContext dapperDataContext, AppDbContext context) : base(dapperDataContext)
        {
            _context = context;
        }

        public bool AddIdCard(IdCard IdCard)
        {
            var existingIdCard = _context.IdCard.FirstOrDefault(u => u.UserName.Equals(IdCard.UserName,
             StringComparison.CurrentCultureIgnoreCase) &&
             u.UserType.Equals(IdCard.UserType, StringComparison.CurrentCultureIgnoreCase));
            if (existingIdCard != null)
            {
                _context.Entry(existingIdCard).CurrentValues.SetValues(IdCard);
                return true;
            }
            else
            {
                _context.IdCard.Add(IdCard); // new entities
            }
            _context.SaveChanges();
            return false;
        }

        public bool DeleteIdCard(string userName, string UserType)
        {
            var user = _context.IdCard
               .FirstOrDefault(p => string.Equals(p.UserName, userName, StringComparison.CurrentCultureIgnoreCase)
                && string.Equals(p.UserType, UserType, StringComparison.CurrentCultureIgnoreCase));
            if (user != null)
            {
                _context.IdCard.Remove(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<IdCard> GetAllIdCard()
        {
            return _context.IdCard;
        }

        public IdCard GetIdCardByUserNameAndUserType(string userName, string UserType)
        {
            var idCard = _context.IdCard
              .FirstOrDefault(p => string.Equals(p.UserName, userName, StringComparison.CurrentCultureIgnoreCase)
               && string.Equals(p.UserType, UserType, StringComparison.CurrentCultureIgnoreCase));
            return idCard;
        }

        public void UpdateIdCard(IdCard IdCard)
        {
            throw new NotImplementedException();
        }
    }
}
