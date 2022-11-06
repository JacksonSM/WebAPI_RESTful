using AluraFlix.Application.UseCases.Commands.Categoria;
using AluraFlix.Exceptions;
using FluentValidation;

namespace AluraFlix.Application.UseCases.Handlers.Categoria;
public class CategoriaValidator : AbstractValidator<CategoriaCommand>
{
    public CategoriaValidator()
    {
        RuleFor(c => c.Titulo)
            .NotEmpty()
            .WithMessage(ResourceMensagensDeErro.CATEGORIA_TITULO_VAZIO)
            .MaximumLength(200)
            .WithMessage(ResourceMensagensDeErro.CATEGORIA_TITULO_MAXIMO200CARACTERES);


        RuleFor(c => c.Cor)
            .NotEmpty()
            .WithMessage(ResourceMensagensDeErro.CATEGORIA_COR_VAZIO)
            .MaximumLength(15)
            .WithMessage(ResourceMensagensDeErro.CATEGORIA_COR_MAXIMO15CARACTERES);
    }
}
