using AluraFlix.Application.UseCases.Commands.Video;
using AluraFlix.Application.UseCases.Results;
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
        IEnumerable<Domain.Entities.Video> videosResult;
        if (command.Search is null)
        {
            videosResult = await _videosRepository.GetAllAsync();
        }
        else
        {
            videosResult = await _videosRepository.GetAllAsync(video => video.Titulo.ToLower()
            .Contains(command.Search.ToLower()));
        }       
        
        if(videosResult.Any())
        {
            return new RequestResult().Ok(videosResult);
        }
        else
        {
            return new RequestResult().NoContext();
        }
    }
}
