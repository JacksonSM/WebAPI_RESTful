using AluraFlix.Application.UseCases.Commands.Categoria;
using AluraFlix.Application.UseCases.Handlers.Categoria.Validators;
using FluentValidation;

namespace AluraFlix.Application.UseCases.Handlers.Categoria.CriarCategoria;
public class CriarCategoriaValidator : AbstractValidator<CriarCategoriaCommand>
{
    public CriarCategoriaValidator()
    {
        RuleFor(x => x).SetValidator(new CategoriaValidator());
    }
}
