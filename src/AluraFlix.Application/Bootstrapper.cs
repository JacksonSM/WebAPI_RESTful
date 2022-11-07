﻿using AluraFlix.Application.Tools;
using AluraFlix.Application.UseCases.Handlers.Categoria;
using AluraFlix.Application.UseCases.Handlers.Categoria.AtualizarCategoria;
using AluraFlix.Application.UseCases.Handlers.Categoria.CriarCategoria;
using AluraFlix.Application.UseCases.Handlers.Video;
using AluraFlix.Application.UseCases.Handlers.Video.AdicionarVideo;
using AluraFlix.Application.UseCases.Handlers.Video.AtualizarVideo;
using Microsoft.Extensions.DependencyInjection;

namespace AluraFlix.Application;
public static class Bootstrapper
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddToolsServices(services);
        AddHandlers(services);
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
                .AddScoped<DeletarVideoHandler>();

        services.AddScoped<CriarCategoriaHandler>()
                .AddScoped<ObterTodasCategoriasHandler>()
                .AddScoped<ObterCategoriaPorIdHandler>()
                .AddScoped<AtualizarCategoriaHandler>();
    }
}
