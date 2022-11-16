using AluraFlix.Application.UseCases.Handlers.Video.AtualizarVideo;
using AluraFlix.Exceptions;
using AluraFlix.Exceptions.ExceptionsBase;
using Utilities.Command;
using Utilities.Entities;
using Utilities.Repositories;

namespace Handlers.Test.Video;
public class AtualizarVideoHandlerTest
{

    [Fact]
    public async Task Sucesso()
    {
        var command = VideoCommandBuilder.AtualizarCommandBuild();
        var videoEntity = VideoBuilder.Build();


        var handler = HandlerBuild(videoEntity, command.CategoriaId);

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
        var command = VideoCommandBuilder.AtualizarCommandBuild();
        command.Titulo = string.Empty;
        var videoEntity = VideoBuilder.Build();

        var handler = HandlerBuild(videoEntity, command.CategoriaId);


        Func<Task> action = async () => { await handler.Handle(command); };

        await action.Should().ThrowAsync<ErrosDeValidacaoException>()
            .Where(exception => exception.MensagensDeErro.Count == 1 && exception.MensagensDeErro.Contains(ResourceMensagensDeErro.VIDEO_TITULO_VAZIO));
    }

    [Fact]
    public async Task ValidarErroCategoriaIdInexistente()
    {
        var command = VideoCommandBuilder.AtualizarCommandBuild();
        var videoEntity = VideoBuilder.Build();
        var handler = HandlerBuild(videoEntity);


        Func<Task> action = async () => { await handler.Handle(command); };

        await action.Should().ThrowAsync<ErrosDeValidacaoException>()
            .Where(exception => exception.MensagensDeErro.Count == 1 && exception.MensagensDeErro.Contains(ResourceMensagensDeErro.CATEGORIA_INEXISTENTE));
    }


    private AtualizarVideoHandler HandlerBuild(AluraFlix.Domain.Entities.Video video, int categoriaId = 0)
    {
        var videoRepo = VideoRepositoryBuilder.Instance().GetById(video).Build();
        var categoriaRepo = CategoriaRepositoryBuilder.Instance().ExistById(categoriaId).Build();
        var uow = UnitOfWorkBuilder.Instance().Build();

        return new AtualizarVideoHandler
            (
                videosRepository: videoRepo,
                categoriaRepository: categoriaRepo,
                uow: uow
            );
    }
}
