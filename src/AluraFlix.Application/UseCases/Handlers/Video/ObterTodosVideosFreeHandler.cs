using AluraFlix.Application.UseCases.Commands.Video;
using AluraFlix.Application.UseCases.Results;
using AluraFlix.Domain.Interfaces;
using Newtonsoft.Json;

namespace AluraFlix.Application.UseCases.Handlers.Video;
public class ObterTodosVideosFreeHandler : IHandler<ObterTodosVideosFreeCommand>
{
    private readonly IVideosRepository _videosRepository;

    public ObterTodosVideosFreeHandler(IVideosRepository videosRepository)
    {
        _videosRepository = videosRepository;
    }

    public async Task<RequestResult> Handle(ObterTodosVideosFreeCommand command)
    {
        (var videos, int qtdVideos) = await _videosRepository.GetAllWithPaginationAsync(
            command.paginaAtual, command.itensPorPagina);

        if (!(videos?.Count() > 0))
            return new RequestResult().NoContext();

        if (command.paginaAtual.HasValue && command.itensPorPagina.HasValue)
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
