using AluraFlix.Application.UseCases.Commands;
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
        var handler = HandlerBuild(videoEntity);

        var response = await handler.Handle(new NoParametersCommand());

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(200);

        var dataResponse = response.Data as IEnumerable<AluraFlix.Domain.Entities.Video>;
        dataResponse.Should().HaveCountGreaterThan(0);
    }

    [Fact]
    public async Task ValidaResultadoSemVideo()
    {
        var handler = HandlerBuild();

        var response = await handler.Handle(new NoParametersCommand());

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(204);
        response.Data.Should().BeNull();
    }


    private ObterTodosVideosHandler HandlerBuild(AluraFlix.Domain.Entities.Video video = null)
    {
        var videoRepo = VideoRepositoryBuilder.Instance().GetAll(video).Build();
        return new ObterTodosVideosHandler
            (
                videoRepository: videoRepo
            );
    }
}
