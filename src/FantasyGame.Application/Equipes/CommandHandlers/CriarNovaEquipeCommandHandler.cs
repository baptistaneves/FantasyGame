using FantasyGame.Application.Equipes.Commands;
using FantasyGame.Application.Common;
using FantasyGame.Domain.Entities;
using FantasyGame.Domain.Interfaces.Notifications;
using FantasyGame.Domain.Interfaces.Repository;
using FantasyGame.Domain.Notifications;
using MediatR;

namespace FantasyGame.Application.Equipes.CommandHandlers
{
    public class CriarNovaEquipeCommandHandler : IRequestHandler<CriarNovaEquipeCommand, Equipe>
    {
        private readonly IEquipeRepository _equipeRepository;
        private readonly INotificador _notificador;
        public CriarNovaEquipeCommandHandler(IEquipeRepository equipeRepository, INotificador notificador)
        {
            _equipeRepository = equipeRepository;
            _notificador = notificador;
        }

        public async Task<Equipe> Handle(CriarNovaEquipeCommand command, CancellationToken cancellationToken)
        {
            if (!ValidarCommando(command)) return null;

            if (EquipeJaExiste(command.Nome)) return null;

            var equipe = Equipe.NovaEquipe(command.Nome, command.Descricao);

            _equipeRepository.Adicionar(equipe);
            await _equipeRepository.UnitOfWork.Salvar(cancellationToken);

            return equipe;
        }

        private bool EquipeJaExiste(string nome)
        {
            if (_equipeRepository.Buscar(e => e.Nome == nome).Result.Any())
            {
                _notificador.publicarNotificacao(new Notificacao(EquipeMessageErrors.EquipeJaExiste));
                return true;
            }

            return false;
        }

        private bool ValidarCommando(Command<Equipe> command)
        {
            if (command.EhValido()) return true;

            command.ValidationResult.Errors.ForEach(error => _notificador.publicarNotificacao(new Notificacao(error.ErrorMessage)));

            return false;
        }
    }
}
