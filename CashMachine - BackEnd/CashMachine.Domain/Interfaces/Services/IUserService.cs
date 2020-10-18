using CashMachine.Domain.Entitys;
using CashMachine.Domain.ViewModel;
using System.Collections.Generic;

namespace CashMachine.Domain.Interfaces
{
    public interface IUserService
    {
        UserVM Adicionar(UserVM entity);
        UserVM Atualizar(string id, UserVM entity);
        bool Remover(string id);
        IEnumerable<UserVM> ObterTodos();
        UserVM ObterPorId(string id);
        UserVM Login(string email, string password);
    }
}
