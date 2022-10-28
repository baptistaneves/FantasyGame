using FantasyGame.Application.Common;
using FantasyGame.Application.Equipes.Commands;
using FantasyGame.Domain.Interfaces.Notifications;
using FantasyGame.Domain.Interfaces.Repository;
using FantasyGame.Domain.Notifications;
using MediatR;

namespace FantasyGame.Application.Equipes.CommandHandlers
{
    public class AtualizarEquipeCommandHandler : IRequestHandler<AtualizarEquipeCommand, bool>
    {
        private readonly IEquipeRepository _equipeRepository;
        private readonly INotificador _notificador;
        public AtualizarEquipeCommandHandler(IEquipeRepository equipeRepository, INotificador notificador)
        {
            _equipeRepository = equipeRepository;
            _notificador = notificador;
        }

        public async Task<bool> Handle(AtualizarEquipeCommand command, CancellationToken cancellationToken)
        {
            if (!ValidarCommando(command)) return false;

            if (EquipeJaExiste(command.Id, command.Nome)) return false;

            var equipe = await _equipeRepository.ObterPorId(command.Id);

            if (equipe == null)
            {
                _notificador.publicarNotificacoes(new Notificacao(EquipeMessageErrors.EquipeNaoEncontrada));
                return false;
            }

            equipe.AtualizarEquipe(command.Nome, command.Descricao);

            _equipeRepository.Atualizar(equipe);
            await _equipeRepository.UnitOfWork.Salvar(cancellationToken);

            return true;
        }

        private bool EquipeJaExiste(Guid id, string nome)
        {
            if (_equipeRepository.Buscar(e => e.Nome == nome && e.Id != id).Result.Any())
            {
                _notificador.publicarNotificacoes(new Notificacao(EquipeMessageErrors.EquipeJaExiste));
                return true;
            }

            return false;
        }

        private bool ValidarCommando(Command<bool> command)
        {
            if (command.EhValido()) return true;

            command.ValidationResult.Errors.ForEach(error => _notificador.publicarNotificacoes(new Notificacao(error.ErrorMessage)));

            return false;
        }
    }
}
