using FantasyGame.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FantasyGame.Infrastructure.Mappings.Equipes
{
    public class EquipeMapping : IEntityTypeConfiguration<Equipe>
    {
        public void Configure(EntityTypeBuilder<Equipe> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasColumnType("varchar(255)");

            builder.Property(e => e.Descricao)
                .IsRequired(false)
                .HasColumnType("varchar(max)");

            builder.ToTable("Equipes");
        }
    }
}
