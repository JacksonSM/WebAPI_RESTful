using AluraFlix.Application.UseCases.Commands;
using AluraFlix.Application.UseCases.Results;
using AluraFlix.Domain.Interfaces;

namespace AluraFlix.Application.UseCases.Handlers.Categoria;
public class ObterVideosPorCategoriaHandler : IHandler<GetByIdCommand>
{
    private readonly ICategoriaRepository _categoriaRepo;
    private readonly IVideosRepository _videosRepo;

    public ObterVideosPorCategoriaHandler(ICategoriaRepository categoriaRepo, IVideosRepository videosRepo)
    {
        _categoriaRepo = categoriaRepo;
        _videosRepo = videosRepo;
    }

    public async Task<RequestResult> Handle(GetByIdCommand command)
    {
        var existeCategoria = await _categoriaRepo.ExistById(command.Id);

        if (!existeCategoria)
            return new RequestResult().NotFound();

        var videos = await _videosRepo.GetAllAsync(video => video.CategoriaId == command.Id);

        if (!videos.Any()) 
            return new RequestResult().NoContext();

        return new RequestResult().Ok(videos);
    }
}
