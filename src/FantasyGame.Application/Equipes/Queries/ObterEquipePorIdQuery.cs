using FantasyGame.Domain.Entities;
using MediatR;

namespace FantasyGame.Application.Equipes.Queries
{
    public class ObterEquipePorIdQuery : IRequest<Equipe>
    {
        public Guid Id { get; private set; }

        public ObterEquipePorIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
