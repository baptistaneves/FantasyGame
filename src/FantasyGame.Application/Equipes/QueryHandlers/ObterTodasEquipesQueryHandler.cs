using FantasyGame.Application.Equipes.Queries;
using FantasyGame.Application.Pagination;
using FantasyGame.Domain.Entities;
using FantasyGame.Domain.Interfaces.Repository;
using MediatR;

namespace FantasyGame.Application.Equipes.QueryHandlers
{
    public class ObterTodasEquipesQueryHandler : IRequestHandler<ObterTodasEquipesQuery, PagedList<Equipe>>
    {
        private readonly IEquipeRepository _equipeRepository;

        public ObterTodasEquipesQueryHandler(IEquipeRepository equipeRepository)
        {
            _equipeRepository = equipeRepository;
        }

        public async Task<PagedList<Equipe>> Handle(ObterTodasEquipesQuery request, CancellationToken cancellationToken)
        {
            var items =  _equipeRepository.ObterTodasEquipes();

            return await PagedList<Equipe>.CreateAsync(items, request.Params.CurrentPage, request.Params.ItemsPerPage);
        }
    }
}
