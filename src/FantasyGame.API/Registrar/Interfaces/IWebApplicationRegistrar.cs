namespace FantasyGame.API.Registrar.Interfaces
{
    public interface IWebApplicationRegistrar : IRegistrar
    {
        void RegisterServices(WebApplication app);
    }
}
