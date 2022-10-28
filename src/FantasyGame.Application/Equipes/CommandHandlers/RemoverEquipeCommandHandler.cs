using FantasyGame.Application.Equipes.Commands;
using FantasyGame.Domain.Entities;
using FantasyGame.Domain.Interfaces.Notifications;
using FantasyGame.Domain.Interfaces.Repository;
using FantasyGame.Domain.Notifications;
using MediatR;

namespace FantasyGame.Application.Equipes.CommandHandlers
{
    public class RemoverEquipeCommandHandler : IRequestHandler<RemoverEquipeCommand, Equipe>
    {
        private readonly IEquipeRepository _equipeRepository;
        private readonly INotificador _notificador;
        public RemoverEquipeCommandHandler(IEquipeRepository equipeRepository, INotificador notificador)
        {
            _equipeRepository = equipeRepository;
            _notificador = notificador;
        }

        public async Task<Equipe> Handle(RemoverEquipeCommand command, CancellationToken cancellationToken)
        {
            var equipe = await _equipeRepository.ObterPorId(command.Id);

            if (equipe == null)
            {
                _notificador.publicarNotificacoes(new Notificacao(EquipeMessageErrors.EquipeNaoEncontrada));
                return null;
            }

            await _equipeRepository.Remover(command.Id);
            await _equipeRepository.UnitOfWork.Salvar(cancellationToken);

            return equipe;
        }
    }
}
