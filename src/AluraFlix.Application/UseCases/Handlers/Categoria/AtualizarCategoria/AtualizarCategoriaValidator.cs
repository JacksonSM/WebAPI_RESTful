using AluraFlix.Application.UseCases.Commands.Categoria;
using AluraFlix.Application.UseCases.Handlers.Categoria.Validators;
using FluentValidation;

namespace AluraFlix.Application.UseCases.Handlers.Categoria.AtualizarCategoria;
internal class AtualizarCategoriaValidator : AbstractValidator<AtualizarCategoriaCommand>
{
    public AtualizarCategoriaValidator()
    {
        RuleFor(x => x).SetValidator(new CategoriaValidator());
    }
}
