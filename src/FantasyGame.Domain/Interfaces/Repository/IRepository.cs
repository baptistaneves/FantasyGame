using FantasyGame.Domain.Entities;
using System.Linq.Expressions;

namespace FantasyGame.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        IUnitOfWork UnitOfWork { get; }

        void Adicionar(TEntity entity);
        void Atualizar(TEntity entity);
        Task Remover(Guid id);

        Task<TEntity> ObterPorId(Guid id);
        Task<IEnumerable<TEntity>> ObterTodos();
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> expression);
    }
}
