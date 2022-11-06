using AluraFlix.Application.UseCases.Commands.Categoria;
using AluraFlix.Exceptions;
using FluentValidation;

namespace AluraFlix.Application.UseCases.Handlers.Categoria.CriarCategoria;
internal class CriarCategoriaValidator : AbstractValidator<CriarCategoriaCommand>
{
    public CriarCategoriaValidator()
    {
        RuleFor(x => x).SetValidator(new CategoriaValidator());

        RuleFor(x => x.Cor)
            .Matches(@"\A\b[0-9a-fA-F]+\b\Z")
            .WithMessage(ResourceMensagensDeErro.CATEGORIA_COR_INVALIDO);
    }
}
