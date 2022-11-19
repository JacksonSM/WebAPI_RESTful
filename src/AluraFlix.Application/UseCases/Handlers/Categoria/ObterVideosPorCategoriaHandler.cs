using AluraFlix.Application.UseCases.Commands.Categoria;
using AluraFlix.Application.UseCases.Results;
using AluraFlix.Domain.Interfaces;
using Newtonsoft.Json;

namespace AluraFlix.Application.UseCases.Handlers.Categoria;

public class ObterVideosPorCategoriaHandler : IHandler<ObterVideosPorCategoriaCommand>
{
    private readonly ICategoriaRepository _categoriaRepo;
    private readonly IVideosRepository _videosRepo;

    public ObterVideosPorCategoriaHandler(ICategoriaRepository categoriaRepo, 
        IVideosRepository videosRepo)
    {
        _categoriaRepo = categoriaRepo;
        _videosRepo = videosRepo;
    }

    public async Task<RequestResult> Handle(ObterVideosPorCategoriaCommand command)
    {
        var existeCategoria = await _categoriaRepo.ExistById(command.Id);

        if (!existeCategoria)
            return new RequestResult().NotFound();

        (var videos, int qtdVideos) = await _videosRepo
            .GetAllWithPaginationAsync(command.paginaAtual, command.itensPorPagina, video => video.CategoriaId == command.Id);

        if (!videos.Any()) 
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
