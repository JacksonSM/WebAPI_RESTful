using AluraFlix.Application.Tools;
using AluraFlix.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AluraFlix.Infrastructure.Context;
public class AluraFlixDbContext : DbContext
{
    public AluraFlixDbContext(DbContextOptions<AluraFlixDbContext> options, PasswordEncryptor encryptor) : base(options)
    {
        _encryptor = encryptor;
    }

    public DbSet<Video> Videos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    private readonly PasswordEncryptor _encryptor;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        InitialConfigDB.CategorialInicial(modelBuilder);
        UsuariosPadraoDb.UsuarioInicial(modelBuilder, _encryptor);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AluraFlixDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
