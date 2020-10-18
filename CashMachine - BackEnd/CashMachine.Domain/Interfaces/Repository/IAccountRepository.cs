using CashMachine.Domain.Entitys;
using CashMachine.Domain.ViewModel;

namespace CashMachine.Domain.Interfaces.Repository
{
    public interface IAccountRepository : IRepository<Account>
    {
        Account GetByUser(string idUser); 
        Account GetById(string id); 
    }
}
