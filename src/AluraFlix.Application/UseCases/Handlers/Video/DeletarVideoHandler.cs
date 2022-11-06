using AluraFlix.Application.UseCases.Commands.Video;
using AluraFlix.Application.UseCases.Results;
using AluraFlix.Domain.Interfaces;

namespace AluraFlix.Application.UseCases.Handlers.Video;
public class DeletarVideoHandler : IHandler<DeletarVideoCommand>
{
    private readonly IVideosRepository _videosRepository;
    private readonly IUnitOfWork _uow;


    public DeletarVideoHandler(
        IVideosRepository videosRepository,
        IUnitOfWork uow)
    {
        _videosRepository = videosRepository;
        _uow = uow;
    }

    public async Task<RequestResult> Handle(DeletarVideoCommand command)
    {
        var video = await _videosRepository.GetByIdAsync(command.Id);

        if (video is null)
            return new RequestResult().NotFound();

        _videosRepository.Remove(video);
        await _uow.CommitAsync();

        return new RequestResult().Ok(video, "Recurso deletado com sucesso!");
    }
}
