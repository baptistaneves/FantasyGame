using FantasyGame.Application.Pagination;
using FantasyGame.Domain.Entities;
using MediatR;

namespace FantasyGame.Application.Equipes.Queries
{
    public class ObterTodasEquipesQuery : IRequest<PagedList<Equipe>>
    {
        public PaginationParams Params { get; private set; }

        public ObterTodasEquipesQuery(PaginationParams @params)
        {
            Params = @params;
        }
    }
}
