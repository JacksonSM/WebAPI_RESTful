using AluraFlix.Application.UseCases.Handlers.Video.AdicionarVideo;
using AluraFlix.Exceptions;
using AluraFlix.Exceptions.ExceptionsBase;
using Utilities.Command;
using Utilities.Repositories;
using Utilities.Tools;

namespace Handlers.Test.Video;
public class AdicionarVideoHandlerTest
{
    [Fact]
    public async Task Sucesso()
    {
        var command = VideoCommandBuilder.AdicionarCommandBuild();

        var handler = HandlerBuild(command.CategoriaId);

        var response = await handler.Handle(command);

        response.Should().NotBeNull();

        var dataResponse = response.Data as AluraFlix.Domain.Entities.Video;

        dataResponse.Titulo.Should().Be(command.Titulo);
        dataResponse.Descricao.Should().Be(command.Descricao);
        dataResponse.URL.Should().Be(command.URL);
        dataResponse.CategoriaId.Should().Be(command.CategoriaId);
    }

    [Fact]
    public async Task ValidarErroTituloVazio()
    {
        var command = VideoCommandBuilder.AdicionarCommandBuild();
        command.Titulo = string.Empty;

        var handler = HandlerBuild(command.CategoriaId);


        Func<Task> action = async () => { await handler.Handle(command); };

        await action.Should().ThrowAsync<ErrosDeValidacaoException>()
            .Where(exception => exception.MensagensDeErro.Count == 1 && exception.MensagensDeErro.Contains(ResourceMensagensDeErro.VIDEO_TITULO_VAZIO));
    }

    [Fact]
    public async Task ValidarErroCategoriaIdInexistente()
    {
        var command = VideoCommandBuilder.AdicionarCommandBuild();

        var handler = HandlerBuild();


        Func<Task> action = async () => { await handler.Handle(command); };

        await action.Should().ThrowAsync<ErrosDeValidacaoException>()
            .Where(exception => exception.MensagensDeErro.Count == 1 && exception.MensagensDeErro.Contains(ResourceMensagensDeErro.CATEGORIA_INEXISTENTE));
    }

    private AdicionarVideoHandler HandlerBuild(int categoriaId = 0)
    {
        var videoRepo = VideoRepositoryBuilder.Instance().Build();
        var categoriaRepo = CategoriaRepositoryBuilder.Instance().ExistById(categoriaId).Build();
        var uow = UnitOfWorkBuilder.Instance().Build();
        var mapper = MapperBuilder.Instance();

        return new AdicionarVideoHandler
            (
                videosRepository: videoRepo,
                categoriaRepository: categoriaRepo,
                mapper: mapper,
                uow: uow
            );
    }
}
