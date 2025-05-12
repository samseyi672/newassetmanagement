using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAsset.Infrastructure.Persistence.Repositories
{
    internal class ClientBankRepository : GenericRepository<ClientBank>, IClientBankRepository
    {

        private readonly AppDbContext _context;
        public ClientBankRepository(DapperDataContext dapperDataContext, AppDbContext context) : base(dapperDataContext)
        {
            _context = context;
        }
        public bool AddClientBank(ClientBank ClientBank)
        {
            var existingClientBank = _context.ClientBank.FirstOrDefault(u => u.BankId.Equals(ClientBank.BankId,
                StringComparison.CurrentCultureIgnoreCase) && u.AccountNumber == ClientBank.AccountNumber && u.UserName.Equals(ClientBank.UserName,
                StringComparison.CurrentCultureIgnoreCase) && u.UserType.Equals(ClientBank.UserType, StringComparison.CurrentCultureIgnoreCase));
            if (existingClientBank != null)
            {
                _context.Entry(existingClientBank).CurrentValues.SetValues(ClientBank);
                return true;
            }
            else
            {
                _context.ClientBank.Add(ClientBank); // new entities
            }
            _context.SaveChanges();
            return false;
        }

        public bool DeleteClientBankByUserNameAndBankIdAndAccountNumber(string userName, string BankId, string AccountNumber, string UserType)
        {
            var user = _context.ClientBank
              .FirstOrDefault(p => string.Equals(p.UserName, userName, StringComparison.CurrentCultureIgnoreCase)
               && string.Equals(p.BankId, BankId, StringComparison.CurrentCultureIgnoreCase)
               && string.Equals(p.AccountNumber, AccountNumber, StringComparison.CurrentCultureIgnoreCase)
               && string.Equals(p.UserType, UserType, StringComparison.CurrentCultureIgnoreCase));
            if (user != null)
            {
                _context.ClientBank.Remove(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<ClientBank> GetAllClientBank()
        {
            return _context.ClientBank;
        }

        public ClientBank GetClientBankByUserNameAndBankIdAndAccountNumber(string userName, string BankId, string AccountNumber, string UserType)
        {
            var existingClientBank = _context.ClientBank.FirstOrDefault(u => u.BankId.Equals(BankId,
               StringComparison.CurrentCultureIgnoreCase) && u.AccountNumber == AccountNumber && u.UserName.Equals(userName,
               StringComparison.CurrentCultureIgnoreCase)
               && u.UserType.Equals(UserType,
               StringComparison.CurrentCultureIgnoreCase));
            return existingClientBank;
        }

        public ClientBank GetClientBankByUserNameAndBankId(string userName, string BankId, string UserType)
        {
            var existingClientBank = _context.ClientBank.FirstOrDefault(u => u.BankId.Equals(BankId,
               StringComparison.CurrentCultureIgnoreCase) && u.UserName.Equals(userName,
               StringComparison.CurrentCultureIgnoreCase)
               && u.UserType.Equals(UserType,
               StringComparison.CurrentCultureIgnoreCase));
            return existingClientBank;
        }

        public void UpdateClientBank(ClientBank clientBank)
        {
            throw new NotImplementedException();
        }
    }
}
