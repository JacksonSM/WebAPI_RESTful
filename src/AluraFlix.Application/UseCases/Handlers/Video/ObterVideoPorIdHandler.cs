using AluraFlix.Application.UseCases.Commands;
using AluraFlix.Application.UseCases.Results;
using AluraFlix.Domain.Interfaces;

namespace AluraFlix.Application.UseCases.Handlers.Video;
public class ObterVideoPorIdHandler : IHandler<GetByIdCommand>
{
    private readonly IVideosRepository _videoRepository;

    public ObterVideoPorIdHandler(IVideosRepository videoRepository)
    {
        _videoRepository = videoRepository;
    }

    public async Task<RequestResult> Handle(GetByIdCommand command)
    {
        var video = await _videoRepository.GetByIdAsync(command.Id);

        if (video is null)
            return new RequestResult().NotFound();

        return new RequestResult().Ok(video);
    }
}
