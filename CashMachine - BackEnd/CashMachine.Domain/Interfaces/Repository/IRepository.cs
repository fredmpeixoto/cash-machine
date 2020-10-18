using System.Collections.Generic;

namespace CashMachine.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Adicionar(TEntity entity);
        TEntity Atualizar(TEntity entity);
        bool Remover(TEntity entity);
        IEnumerable<TEntity> GetAll();
    }
}
