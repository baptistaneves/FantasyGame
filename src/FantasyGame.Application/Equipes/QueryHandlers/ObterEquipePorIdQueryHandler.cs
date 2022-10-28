using FantasyGame.Application.Equipes.Queries;
using FantasyGame.Domain.Entities;
using FantasyGame.Domain.Interfaces.Notifications;
using FantasyGame.Domain.Interfaces.Repository;
using FantasyGame.Domain.Notifications;
using MediatR;

namespace FantasyGame.Application.Equipes.QueryHandlers
{
    public class ObterEquipePorIdQueryHandler : IRequestHandler<ObterEquipePorIdQuery, Equipe>
    {
        private readonly IEquipeRepository _equipeRepository;
        private readonly INotificador _notificador;

        public ObterEquipePorIdQueryHandler(IEquipeRepository equipeRepository, INotificador notificador)
        {
            _equipeRepository = equipeRepository;
            _notificador = notificador;
        }

        public async Task<Equipe> Handle(ObterEquipePorIdQuery request, CancellationToken cancellationToken)
        {
            var equipe = await _equipeRepository.ObterPorId(request.Id);

            if (equipe == null)
            {
                _notificador.publicarNotificacoes(new Notificacao(EquipeMessageErrors.EquipeNaoEncontrada));
                return null;
            }

            return equipe;
        }
    }
}
