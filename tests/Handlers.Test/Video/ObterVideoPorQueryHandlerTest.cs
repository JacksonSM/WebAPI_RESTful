using AluraFlix.Application.UseCases.Commands.Video;
using AluraFlix.Application.UseCases.Handlers.Video;
using Utilities.Entities;
using Utilities.Repositories;

namespace Handlers.Test.Video;
public class ObterVideoPorQueryHandlerTest
{
    [Fact]
    public async Task EntradaComQueryEsperaRetornoComValores()
    {
        var videoFaker = VideoBuilder.Build();
        var command = new GetByQueryCommand() { Search = "Alguma coisa." };

        var handler = HandlerBuild(videoFaker, command.Search);

        var response = await handler.Handle(command);

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(200);

        var dataResponse = response.Data as IEnumerable<AluraFlix.Domain.Entities.Video>;
        dataResponse.Should().HaveCountGreaterThan(0);
    }

    [Fact]
    public async Task EntradaComQueryEsperaRetornoSemValores()
    {
        var command = new GetByQueryCommand() { Search = "Alguma coisa que não existe no banco" };

        var handler = HandlerBuild();

        var response = await handler.Handle(command);

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(204);
        response.Data.Should().BeNull();
    }

    [Fact]
    public async Task EntradaSemQueryEsperaRetornoSemValores()
    {
        var handler = HandlerBuild();
        var command = new GetByQueryCommand();

        var response = await handler.Handle(command);

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(204);
        response.Data.Should().BeNull();
    }

    [Fact]
    public async Task EntradaSemQueryEsperaRetornoComValores()
    {
        var videoFaker = VideoBuilder.Build();
        var handler = HandlerBuild(videoGetAll: videoFaker);
        var command = new GetByQueryCommand();

        var response = await handler.Handle(command);

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(200);

        var dataResponse = response.Data as IEnumerable<AluraFlix.Domain.Entities.Video>;
        dataResponse.Should().HaveCountGreaterThan(0);
    }


    private ObterVideoPorQueryHandler HandlerBuild
        (AluraFlix.Domain.Entities.Video videoGetAll = null, string query = "")
    {
        var videoRepo = VideoRepositoryBuilder.Instance()
            .GetAll(videoGetAll, query)
            .Build();

        return new ObterVideoPorQueryHandler
            (
                videosRepository: videoRepo
            );
    }
}
