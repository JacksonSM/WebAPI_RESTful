using AluraFlix.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AluraFlix.Infrastructure.Context;
public class AluraFlixDbContext : DbContext
{
    public AluraFlixDbContext(DbContextOptions<AluraFlixDbContext> options) : base(options) {}

    public DbSet<Video> Videos { get; set; }

}
