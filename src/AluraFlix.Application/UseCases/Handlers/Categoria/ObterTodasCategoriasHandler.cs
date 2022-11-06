using AluraFlix.Application.UseCases.Commands;
using AluraFlix.Application.UseCases.Results;
using AluraFlix.Domain.Interfaces;

namespace AluraFlix.Application.UseCases.Handlers.Categoria;
public class ObterTodasCategoriasHandler : IHandler<NoParametersCommand>
{
    private readonly ICategoriaRepository _categoriaRepository;

    public ObterTodasCategoriasHandler(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public async Task<RequestResult> Handle(NoParametersCommand command)
    {
        var categorias = await _categoriaRepository.GetAllAsync();

        if (categorias.Count() == 0)
            return new RequestResult().NoContext();

        return new RequestResult().Ok(categorias);
    }
}
