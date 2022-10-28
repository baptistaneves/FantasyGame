using FantasyGame.Domain.Entities;
using FantasyGame.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace FantasyGame.Infrastructure.Context
{
    public class ApplicationContext : DbContext, IUnitOfWork
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }

        public async Task<bool> Salvar(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken) > 0;
        }

        public DbSet<Equipe> Equipes { get; set; }
    }
}
