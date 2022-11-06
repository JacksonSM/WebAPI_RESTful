using AluraFlix.Application.UseCases.Commands.Video;
using AluraFlix.Application.UseCases.Results;
using AluraFlix.Domain.Interfaces;
using AluraFlix.Exceptions;
using AluraFlix.Exceptions.ExceptionsBase;
using AutoMapper;


namespace AluraFlix.Application.UseCases.Handlers.Video.AdicionarVideo;

public class AdicionarVideoHandler : IHandler<AdicionarVideoCommand>
{
    private readonly IVideosRepository _videosRepository;
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public AdicionarVideoHandler(
        IVideosRepository videosRepository,
        ICategoriaRepository categoriaRepository,
        IUnitOfWork uow,
        IMapper mapper)
    {
        _videosRepository = videosRepository;
        _categoriaRepository = categoriaRepository;
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<RequestResult> Handle(AdicionarVideoCommand command)
    {
        await ValidarAsync(command);

        var entity = _mapper.Map<Domain.Entities.Video>(command);

        await _videosRepository.AddAsync(entity);
        await _uow.CommitAsync();
        return new RequestResult().Created(entity);
    }

    private async Task ValidarAsync(AdicionarVideoCommand command)
    {
        var validator = new AdicionarVideoValidator();
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
