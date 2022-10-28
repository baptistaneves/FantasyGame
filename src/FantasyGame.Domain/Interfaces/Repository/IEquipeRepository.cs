using FantasyGame.Domain.Entities;

namespace FantasyGame.Domain.Interfaces.Repository
{
    public interface IEquipeRepository : IRepository<Equipe> 
    {
        IQueryable<Equipe> ObterTodasEquipes();
        Task<List<Equipe>> ObterEquipesAleatorias();
    }
}
