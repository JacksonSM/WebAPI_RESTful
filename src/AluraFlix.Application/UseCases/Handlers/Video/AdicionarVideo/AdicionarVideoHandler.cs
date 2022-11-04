using AluraFlix.Application.UseCases.Commands.Video;
using AluraFlix.Application.UseCases.Results;
using AluraFlix.Domain.Interfaces;
using AluraFlix.Exceptions.ExceptionsBase;
using AutoMapper;


namespace AluraFlix.Application.UseCases.Handlers.Video.AdicionarVideo;

public class AdicionarVideoHandler : IHandler<AdicionarVideoCommand>
{
    private readonly IVideosRepository _videosRepository;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public AdicionarVideoHandler(
        IVideosRepository videosRepository,
        IUnitOfWork uow,
        IMapper mapper)
    {
        _videosRepository = videosRepository;
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<RequestResult> Handle(AdicionarVideoCommand command)
    {
        Validar(command);

        var entity = _mapper.Map<Domain.Entities.Video>(command);

        await _videosRepository.AddAsync(entity);
        await _uow.CommitAsync();
        return new RequestResult().Created(entity);
    }

    private void Validar(AdicionarVideoCommand command)
    {
        var validator = new AdicionarVideoValidator();
        var validationResult = validator.Validate(command);

        if (!validationResult.IsValid)
        {
            var mensagesDeErro = validationResult.Errors.Select(c => c.ErrorMessage).ToList();
            throw new ErrosDeValidacaoException(mensagesDeErro);
        }
    }
}
