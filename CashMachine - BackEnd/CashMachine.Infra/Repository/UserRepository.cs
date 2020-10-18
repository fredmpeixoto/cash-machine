using CashMachine.Domain.Entitys;
using CashMachine.Domain.Interfaces.Repository;
using CashMachine.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace CashMachine.Infra.Repository
{
    public class UserRepository : EFRepository<User>, IUserRepository
    {

        public UserRepository(UserContext userContext) : base(userContext)
        {

        }

        public IEnumerable<object> GetAllUserAndAccount()
        {
            return _dbContext.Set<User>().Join(_dbContext.Set<Account>(), a => a.Id, b=> b.UserId, (user, account) => new { user, account })
                .AsEnumerable();
        }

        public User Logar(string email, string password)
        {
            return (_dbContext.Set<User>().FirstOrDefault(f => f.Email == email && f.Password == password));         
        }

        public User ObterPorEmail(string email)
        {
            return (_dbContext.Set<User>().FirstOrDefault(f => f.Email.Trim() == email.Trim() ));
        }

        public User ObterPorId(string id)
        {
            return _dbContext.Set<User>().FirstOrDefault(w => w.Id.ToString() == id);
        }


    }
}
