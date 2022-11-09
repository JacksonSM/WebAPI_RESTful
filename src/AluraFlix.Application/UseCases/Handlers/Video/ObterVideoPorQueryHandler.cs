using AluraFlix.Application.UseCases.Commands.Video;
using AluraFlix.Application.UseCases.Results;
using AluraFlix.Domain.Entities;
using AluraFlix.Domain.Interfaces;

namespace AluraFlix.Application.UseCases.Handlers.Video;
public class ObterVideoPorQueryHandler : IHandler<GetByQueryCommand>
{
    private readonly IVideosRepository _videosRepository;

    public ObterVideoPorQueryHandler(IVideosRepository videosRepository)
    {
        _videosRepository = videosRepository;
    }

    public async Task<RequestResult> Handle(GetByQueryCommand command)
    {
        IEnumerable<Domain.Entities.Video> videos;
        if (command.Search is null)
        {
            videos = await _videosRepository.GetAllAsync();
        }
        else
        {
            videos = await _videosRepository.GetAllAsync(video => video.Titulo.ToLower()
            .Contains(command.Search.ToLower()));
        }       
        
        if(videos.Any())
        {
            return new RequestResult().Ok(videos);
        }
        else
        {
            return new RequestResult().NoContext();
        }
    }
}
