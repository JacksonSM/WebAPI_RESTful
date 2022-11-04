using AluraFlix.Application.UseCases.Commands;
using AluraFlix.Application.UseCases.Results;
using AluraFlix.Domain.Interfaces;

namespace AluraFlix.Application.UseCases.Handlers.Video;

public class ObterTodosVideosHandler : IHandler<NoParametersCommand>
{
    private readonly IVideosRepository _videoRepository;

    public ObterTodosVideosHandler(IVideosRepository videoRepository)
    {
        _videoRepository = videoRepository;
    }

    public async Task<RequestResult> Handle(NoParametersCommand command)
    {
        var videos = await _videoRepository.GetAllAsync();

        if (!(videos?.Count() > 0))
            return new RequestResult().NoContext();

        return new RequestResult().Ok(videos);
    }
}
