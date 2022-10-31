using AluraFlix.Domain.Interfaces;
using AluraFlix.Infrastructure.Context;
using AluraFlix.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AluraFlix.Infrastructure;
public static class Bootstrapper
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        var ConnectionString = @"Data Source=Database//BancoAluraFlix.db";

        services.AddDbContext<AluraFlixDbContext>(options =>
            options.UseSqlite(ConnectionString));
        AddRepository(services);
    }
    static void AddRepository(IServiceCollection services)
    {
        services.AddScoped<IVideosRepository, VideoRepository>();
    }
}
