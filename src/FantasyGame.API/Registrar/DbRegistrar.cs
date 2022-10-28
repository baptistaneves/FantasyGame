using FantasyGame.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FantasyGame.API.Registrar
{
    public class DbRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            var cs = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(cs));

            builder.Services.AddScoped<ApplicationContext>();
        }
    }
}
