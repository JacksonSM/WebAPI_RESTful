using AluraFlix.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluraFlix.Infrastructure.Context.EntitiesMap;
public class CategoriaMap : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(c => c.Titulo)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(c => c.Cor)
               .IsRequired()
               .HasMaxLength(200);

        builder.HasMany(r => r.Videos).WithOne().HasForeignKey(r => r.CategoriaId);
    }
}
