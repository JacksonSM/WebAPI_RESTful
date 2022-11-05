using AluraFlix.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluraFlix.Infrastructure.Context.EntitiesMap;
public class VideoMap : IEntityTypeConfiguration<Video>
{
    public void Configure(EntityTypeBuilder<Video> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(c => c.Titulo)
               .IsRequired()
               .HasMaxLength(300);

        builder.Property(c => c.Descricao)
               .IsRequired()
               .HasMaxLength(600);

        builder.Property(c => c.URL)
               .IsRequired();

        builder.Property(c => c.CategoriaId)
               .HasDefaultValue(1);

    }
}
