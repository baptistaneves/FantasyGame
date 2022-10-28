using FantasyGame.Domain.Notifications;

namespace FantasyGame.Domain.Interfaces.Notifications
{
    public interface INotificador : IDisposable
    {
        bool TemNotificacoes();
        List<Notificacao> ObterNotificacoes();
        void publicarNotificacao(Notificacao notification);
    }
}
