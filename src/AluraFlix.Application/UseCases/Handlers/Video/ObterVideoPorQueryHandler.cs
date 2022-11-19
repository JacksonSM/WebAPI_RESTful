using AluraFlix.Application.UseCases.Commands.Video;
using AluraFlix.Application.UseCases.Results;
using AluraFlix.Domain.Interfaces;
using Newtonsoft.Json;

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
        int qtdVideos = 0;
        if (command.Search is null)
        {
            (videosResult, qtdVideos) = await _videosRepository.GetAllWithPaginationAsync(command.paginaAtual, command.itensPorPagina);
        }
        else
        {
            (videosResult, qtdVideos)= await _videosRepository.GetAllWithPaginationAsync(command.paginaAtual, command.itensPorPagina, video => video.Titulo.ToLower()
            .Contains(command.Search.ToLower()));
        }       
        
        if(videosResult.Any())
        {
            if (command.itensPorPagina.HasValue && command.paginaAtual.HasValue)
            {
                var paginacao = new PaginacaoHeader
                    (
                        paginaAtual: command.paginaAtual.Value,
                        itensPorPagina: command.itensPorPagina.Value,
                        totalItens: qtdVideos
                    );

                var paginacaoHeader = new Tuple<string, string>(paginacao.Chave, JsonConvert.SerializeObject(paginacao));
                return new RequestResult().Ok(videosResult, paginacaoHeader);
            }
            return new RequestResult().Ok(videosResult);
        }
        else
        {
            return new RequestResult().NoContext();
        }
    }
}
