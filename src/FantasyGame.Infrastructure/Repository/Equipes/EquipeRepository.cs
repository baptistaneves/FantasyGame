using FantasyGame.Domain.Entities;
using FantasyGame.Domain.Interfaces.Repository;
using FantasyGame.Infrastructure.Context;
using FantasyGame.Infrastructure.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace FantasyGame.Infrastructure.Repository.Equipes
{
    public class EquipeRepository : Repository<Equipe>, IEquipeRepository
    {
        public EquipeRepository(ApplicationContext context) : base(context) { }

        public async Task<List<Equipe>> ObterEquipesAleatorias()
        {
            return await _context.Equipes.AsNoTracking()
                    .OrderBy(equipe => Guid.NewGuid())
                    .ToListAsync();
        }

        public IQueryable<Equipe> ObterTodasEquipes()
        {
            return _context.Equipes.AsNoTracking().OrderBy(e=> e.Nome).AsQueryable();
        }
    }
}
