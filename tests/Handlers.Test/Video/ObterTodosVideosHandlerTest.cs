using AluraFlix.Application.UseCases.Commands;
using AluraFlix.Application.UseCases.Commands.Video;
using AluraFlix.Application.UseCases.Handlers.Video;
using Utilities.Entities;
using Utilities.Repositories;

namespace Handlers.Test.Video;
public class ObterTodosVideosHandlerTest
{
    [Fact]
    public async Task Sucesso()
    {
        var videoEntity = VideoBuilder.Build();

        var command = new ObterTodosVideosCommand();

        var handler = HandlerBuild
            (
                paginaAtual: command.paginaAtual,
                videosPorPagina: command.itensPorPagina, 
                video: videoEntity
            );

        var response = await handler.Handle(command);

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(200);

        var dataResponse = response.Data as IEnumerable<AluraFlix.Domain.Entities.Video>;
        dataResponse.Should().HaveCountGreaterThan(0);
    }

    [Fact]
    public async Task ValidaResultadoSemVideo()
    {
        var handler = HandlerBuild();

        var response = await handler.Handle(new ObterTodosVideosCommand());

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(204);
        response.Data.Should().BeNull();
    }


    private ObterTodosVideosHandler HandlerBuild
        (int? paginaAtual = null,
        int? videosPorPagina = null, AluraFlix.Domain.Entities.Video video = null, string? query = null)
    {
        var videoRepo = VideoRepositoryBuilder.Instance()
            .GetAll(query, video, paginaAtual, videosPorPagina)
            .Build();

        return new ObterTodosVideosHandler
            (
                videoRepository: videoRepo
            );
    }
}
