using FantasyGame.Domain.Interfaces.Notifications;

namespace FantasyGame.Domain.Notifications
{
    public class Notificador : INotificador
    {
        private List<Notificacao> _notificacoes;
        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes.ToList();
        }

        public void publicarNotificacao(Notificacao notification)
        {
            _notificacoes.Add(notification);
        }

        public bool TemNotificacoes()
        {
           return _notificacoes.Any();
        }

        public void Dispose()
        {
            _notificacoes = new List<Notificacao>();
        }
    }
}
