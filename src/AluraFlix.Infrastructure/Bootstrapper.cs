using AluraFlix.Domain.Interfaces;
using AluraFlix.Infrastructure.Context;
using AluraFlix.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AluraFlix.Infrastructure;
public static class Bootstrapper
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var ConnectionString = configuration["ConnectionString"];

        services.AddDbContext<AluraFlixDbContext>(options =>
            options.UseSqlite(ConnectionString));
        AddRepository(services);
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
    static void AddRepository(IServiceCollection services)
    {
        services.AddScoped<IVideosRepository, VideoRepository>();
        services.AddScoped<ICategoriaRepository, CategoriaRepository>();
    }
}
