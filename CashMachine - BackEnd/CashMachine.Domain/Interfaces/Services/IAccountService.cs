using CashMachine.Domain.Entitys;
using CashMachine.Domain.ViewModel;

namespace CashMachine.Domain.Interfaces.Services
{
    public interface IAccountService
    {
        AccountVM Adicionar(AccountVM entity);
        AccountVM AtualizarById(string id,AccountVM entity);
        AccountVM ObterPorIdUser(string id);
        AccountVM RemoveMoney(string idUser, double removeValue);
    }
}
