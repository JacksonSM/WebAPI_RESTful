using AluraFlix.Application.UseCases.Commands.Video;
using AluraFlix.Application.UseCases.Results;
using AluraFlix.Domain.Interfaces;
using Newtonsoft.Json;

namespace AluraFlix.Application.UseCases.Handlers.Video;

public class ObterTodosVideosHandler : IHandler<ObterTodosVideosCommand>
{
    private readonly IVideosRepository _videoRepository;

    public ObterTodosVideosHandler(IVideosRepository videoRepository)
    {
        _videoRepository = videoRepository;
    }

    public async Task<RequestResult> Handle(ObterTodosVideosCommand command)
    {
        IEnumerable<Domain.Entities.Video> videos;
        int qtdVideos = 0;

        if (string.IsNullOrEmpty(command.Search))
        {
             (videos, qtdVideos) = await _videoRepository.GetAllWithPaginationAsync
                (
                    command.paginaAtual,
                    command.itensPorPagina
                );
        }
        else
        {
              (videos, qtdVideos) = await _videoRepository.GetAllWithPaginationAsync
                (
                    command.paginaAtual,
                    command.itensPorPagina,
                    filtro: video => video.Titulo.ToLower().Contains(command.Search.ToLower())
                );
        }

        if (!(videos?.Count() > 0))
            return new RequestResult().NoContext();

        if(command.paginaAtual.HasValue && command.itensPorPagina.HasValue)
        {
            var paginacao = new PaginacaoHeader
                (
                    paginaAtual: command.paginaAtual.Value,
                    itensPorPagina: command.itensPorPagina.Value,
                    totalItens: qtdVideos
                );

            var paginacaoHeader = new Tuple<string, string>(paginacao.Chave, JsonConvert.SerializeObject(paginacao));

            return new RequestResult().Ok(videos, paginacaoHeader);
        }

        return new RequestResult().Ok(videos);
    }
}
