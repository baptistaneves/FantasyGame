using FantasyGame.Application.Common;
using FantasyGame.Domain.Entities;

namespace FantasyGame.Application.Equipes.Commands
{
    public class RemoverEquipeCommand : Command<Equipe>
    {
        public Guid Id { get; private set; }

        public RemoverEquipeCommand(Guid id)
        {
            Id = id;
        }
    }
}
