using CashMachine.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashMachine.Domain.Interfaces.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User ObterPorId(string id);
        User Logar(string email,string password);
        User ObterPorEmail(string email);

    }
}
