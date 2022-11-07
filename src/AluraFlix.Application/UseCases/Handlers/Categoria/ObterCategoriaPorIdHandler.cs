using AluraFlix.Application.UseCases.Commands;
using AluraFlix.Application.UseCases.Results;
using AluraFlix.Domain.Interfaces;

namespace AluraFlix.Application.UseCases.Handlers.Categoria;
public class ObterCategoriaPorIdHandler : IHandler<GetByIdCommand>
{
    private readonly ICategoriaRepository _categoriaRepository;

    public ObterCategoriaPorIdHandler(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public async Task<RequestResult> Handle(GetByIdCommand command)
    {
        var video = await _categoriaRepository.GetByIdAsync(command.Id);

        if (video is null)
            return new RequestResult().NotFound();

        return new RequestResult().Ok(video);
    }

}
