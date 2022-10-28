namespace FantasyGame.Domain.Notifications
{
    public class Notificacao
    {
        public string Message { get; private set; }

        public Notificacao(string message)
        {
            Message = message;
        }
    }
}
