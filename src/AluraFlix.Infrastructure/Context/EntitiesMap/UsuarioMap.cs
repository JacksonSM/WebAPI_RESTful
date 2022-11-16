using AluraFlix.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluraFlix.Infrastructure.Context.EntitiesMap;
public class UsuarioMap : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(c => c.Nome)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(c => c.Email)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(c => c.Senha)
               .IsRequired();
    }
}
