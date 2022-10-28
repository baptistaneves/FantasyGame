using FantasyGame.Domain.Interfaces.Notifications;
using FantasyGame.Domain.Interfaces.Repository;
using FantasyGame.Domain.Notifications;
using FantasyGame.Infrastructure.Repository.Equipes;

namespace FantasyGame.API.Registrar
{
    public class InfrastructureLayerRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IEquipeRepository, EquipeRepository>();
            builder.Services.AddScoped<INotificador, Notificador>();
        }
    }
}
