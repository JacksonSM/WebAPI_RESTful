using AluraFlix.Application.UseCases.Commands.Video;
using AluraFlix.Application.UseCases.Results;
using AluraFlix.Domain.Interfaces;
using AluraFlix.Exceptions;
using AluraFlix.Exceptions.ExceptionsBase;
using AutoMapper;

namespace AluraFlix.Application.UseCases.Handlers.Video.AtualizarVideo;
public class AtualizarVideoHandler : IHandler<AtualizarVideoCommand>
{
    private readonly IVideosRepository _videosRepository;
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly IUnitOfWork _uow;

    public AtualizarVideoHandler(
        IVideosRepository videosRepository,
        ICategoriaRepository categoriaRepository,
        IUnitOfWork uow)
    {
        _videosRepository = videosRepository;
        _categoriaRepository = categoriaRepository;
        _uow = uow;
    }

    public async Task<RequestResult> Handle(AtualizarVideoCommand command)
    {
        await ValidarAsync(command);

        var video = await _videosRepository.GetByIdAsync(command.Id);

        if (video is null)
            return new RequestResult().NotFound();

        video.Update(command.Titulo, command.Descricao, command.URL);

        _videosRepository.Update(video);
        await _uow.CommitAsync();

        return new RequestResult().Ok(video);
    }

    private async Task ValidarAsync(AtualizarVideoCommand command)
    {
        var validator = new AtualizarVideoValidator();
        var validationResult = validator.Validate(command);

        bool existeCategoria = await _categoriaRepository.ExistById(command.CategoriaId);
        if (!existeCategoria) validationResult.Errors
                .Add(new FluentValidation.Results.ValidationFailure(string.Empty, ResourceMensagensDeErro.CATEGORIA_INEXISTENTE));

        if (!validationResult.IsValid)
        {
            var mensagesDeErro = validationResult.Errors.Select(c => c.ErrorMessage).ToList();
            throw new ErrosDeValidacaoException(mensagesDeErro);
        }
    }
}
