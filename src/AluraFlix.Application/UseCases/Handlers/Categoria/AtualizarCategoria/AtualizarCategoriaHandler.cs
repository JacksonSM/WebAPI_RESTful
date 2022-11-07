using AluraFlix.Application.UseCases.Commands.Categoria;
using AluraFlix.Application.UseCases.Results;
using AluraFlix.Domain.Interfaces;
using AluraFlix.Exceptions.ExceptionsBase;

namespace AluraFlix.Application.UseCases.Handlers.Categoria.AtualizarCategoria;
public class AtualizarCategoriaHandler : IHandler<AtualizarCategoriaCommand>
{
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly IUnitOfWork _uow;

    public AtualizarCategoriaHandler(
        ICategoriaRepository categoriaRepository,
        IUnitOfWork uow)
    {
        _categoriaRepository = categoriaRepository;
        _uow = uow;
    }

    public async Task<RequestResult> Handle(AtualizarCategoriaCommand command)
    {
        Validar(command);

        var Categoria = await _categoriaRepository.GetByIdAsync(command.Id);

        if (Categoria is null)
            return new RequestResult().NotFound();

        Categoria.Update(command.Titulo, command.Cor);

        _categoriaRepository.Update(Categoria);
        await _uow.CommitAsync();

        return new RequestResult().Ok(Categoria);
    }

    private void Validar(AtualizarCategoriaCommand command)
    {
        var validator = new AtualizarCategoriaValidator();
        var validationResult = validator.Validate(command);


        if (!validationResult.IsValid)
        {
            var mensagesDeErro = validationResult.Errors.Select(c => c.ErrorMessage).ToList();
            throw new ErrosDeValidacaoException(mensagesDeErro);
        }
    }
}
