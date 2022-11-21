using AluraFlix.Application.Tools;
using AluraFlix.Application.UseCases.Handlers.Categoria;
using AluraFlix.Application.UseCases.Handlers.Categoria.AtualizarCategoria;
using AluraFlix.Application.UseCases.Handlers.Categoria.CriarCategoria;
using AluraFlix.Application.UseCases.Handlers.Usuario;
using AluraFlix.Application.UseCases.Handlers.Video;
using AluraFlix.Application.UseCases.Handlers.Video.AdicionarVideo;
using AluraFlix.Application.UseCases.Handlers.Video.AtualizarVideo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AluraFlix.Application;
public static class Bootstrapper
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        AddToolsServices(services);
        AddHandlers(services);
        AddTokenService(services, configuration);
        AddEncriptadorService(services, configuration);
    }

    private static void AddToolsServices(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MapperConfig));

    }
    private static void AddHandlers(IServiceCollection services)
    {
        services.AddScoped<AdicionarVideoHandler>()
                .AddScoped<ObterTodosVideosHandler>()
                .AddScoped<ObterVideoPorIdHandler>()
                .AddScoped<AtualizarVideoHandler>()
                .AddScoped<DeletarVideoHandler>()
                .AddScoped<ObterVideoPorQueryHandler>()
                .AddScoped<ObterTodosVideosFreeHandler>();

        services.AddScoped<CriarCategoriaHandler>()
                .AddScoped<ObterTodasCategoriasHandler>()
                .AddScoped<ObterCategoriaPorIdHandler>()
                .AddScoped<AtualizarCategoriaHandler>()
                .AddScoped<DeletarCategoriaHandler>()
                .AddScoped<ObterVideosPorCategoriaHandler>();

        services.AddScoped<UsuarioLoginHandler>();
    }

    private static void AddEncriptadorService(IServiceCollection services, IConfiguration configuration)
    {
        var chaveAdicional = configuration.GetRequiredSection("Settings:Senha:ChaveAdicionalSenha");

        services.AddScoped(option => new PasswordEncryptor(chaveAdicional.Value));
    }

    private static void AddTokenService(IServiceCollection services, IConfiguration configuration)
    {
        var sectionTempoDeVida = configuration.GetRequiredSection("Settings:Jwt:TempoVidaTokenMinutos");
        var sectionKey = configuration.GetRequiredSection("Settings:Jwt:ChaveToken");

        services.AddScoped(option => new TokenController(int.Parse(sectionTempoDeVida.Value), sectionKey.Value));
    }
}
