using FantasyGame.Domain.Entities;
using FantasyGame.Domain.Interfaces.Repository;
using FantasyGame.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FantasyGame.Infrastructure.Repository.Generic
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly ApplicationContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public IUnitOfWork UnitOfWork => _context;
        protected Repository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.AsNoTracking().Where(expression).ToListAsync();
        }

        public async Task<TEntity> ObterPorId(Guid id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(e=> e.Id == id);
        }

        public async Task<IEnumerable<TEntity>> ObterTodos()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public void Adicionar(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Atualizar(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public async Task Remover(Guid id)
        {
            _dbSet.Remove(await _dbSet.FindAsync(id));
        }
        public void Dispose()
        {
           _context?.Dispose();
        }
    }
}
