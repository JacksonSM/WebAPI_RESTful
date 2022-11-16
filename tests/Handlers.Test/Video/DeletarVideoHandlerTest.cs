using AluraFlix.Application.UseCases.Commands;
using AluraFlix.Application.UseCases.Commands.Video;
using AluraFlix.Application.UseCases.Handlers.Video;
using Utilities.Entities;
using Utilities.Repositories;

namespace Handlers.Test.Video;
public class DeletarVideoHandlerTest
{
    [Fact]
    public async Task Sucesso()
    {
        var videoEntity = VideoBuilder.Build();
        var command = new DeletarVideoCommand { Id = videoEntity.Id };
        var handler = HandlerBuild(videoEntity);

        var response = await handler.Handle(command);

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(200);

        var dataResponse = response.Data as AluraFlix.Domain.Entities.Video;
        dataResponse.Titulo.Should().Be(videoEntity.Titulo);
        dataResponse.Descricao.Should().Be(videoEntity.Descricao);
        dataResponse.URL.Should().Be(videoEntity.URL);
        dataResponse.CategoriaId.Should().Be(videoEntity.CategoriaId);
    }

    [Fact]
    public async Task ValidaErroVideoInexistente()
    {
        var videoEntity = VideoBuilder.Build();
        videoEntity.Id = 3;
        var command = new DeletarVideoCommand { Id = 6 };
        var handler = HandlerBuild(videoEntity);

        var response = await handler.Handle(command);

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(404);
    }

    private DeletarVideoHandler HandlerBuild(AluraFlix.Domain.Entities.Video video)
    {
        var videoRepo = VideoRepositoryBuilder.Instance().GetById(video).Build();
        var uow = UnitOfWorkBuilder.Instance().Build();

        return new DeletarVideoHandler
            (
                videosRepository: videoRepo,
                uow: uow
            );
    }
}
