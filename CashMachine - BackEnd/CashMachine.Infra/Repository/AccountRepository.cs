using CashMachine.Domain.Entitys;
using CashMachine.Domain.Interfaces.Repository;
using CashMachine.Domain.ViewModel;
using CashMachine.Infra.Data;
using System.Linq;

namespace CashMachine.Infra.Repository
{
    public class AccountRepository : EFRepository<Account>, IAccountRepository
    {

        public AccountRepository(UserContext userContext) : base(userContext)
        {

        }

        public Account GetById(string id)
        {
            return _dbContext.Set<Account>().FirstOrDefault(w => w.Id.ToString().Trim() == id.Trim());
        }

        public Account GetByUser(string idUser)
        {
            return _dbContext.Set<Account>().FirstOrDefault(w => w.UserId.ToString().Trim() == idUser.Trim());
        }
    }
}
