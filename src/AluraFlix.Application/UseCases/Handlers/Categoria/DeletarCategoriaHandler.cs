using AluraFlix.Application.UseCases.Commands.Categoria;
using AluraFlix.Application.UseCases.Results;
using AluraFlix.Domain.Interfaces;

namespace AluraFlix.Application.UseCases.Handlers.Categoria;
public class DeletarCategoriaHandler : IHandler<DeletarCategoriaCommand>
{
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly IUnitOfWork _uow;


    public DeletarCategoriaHandler(
        ICategoriaRepository categoriaRepository,
        IUnitOfWork uow)
    {
        _categoriaRepository = categoriaRepository;
        _uow = uow;
    }

    public async Task<RequestResult> Handle(DeletarCategoriaCommand command)
    {
        var video =  await _categoriaRepository.GetByIdAsync(command.Id);

        if (video is null)
            return new RequestResult().NotFound();

        _categoriaRepository.Remove(video);
        await _uow.CommitAsync();

        return new RequestResult().Ok(video, "Recurso deletado com sucesso!");
    }
}
