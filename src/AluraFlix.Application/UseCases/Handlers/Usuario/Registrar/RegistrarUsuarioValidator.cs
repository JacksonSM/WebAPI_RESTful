using AluraFlix.Application.UseCases.Commands.Categoria;
using AluraFlix.Application.UseCases.Commands.Usuario;
using AluraFlix.Exceptions;
using FluentValidation;

namespace AluraFlix.Application.UseCases.Handlers.Usuario.Registrar;
public class RegistrarUsuarioValidator : AbstractValidator<RegistrarUsuarioCommand>
{
    public RegistrarUsuarioValidator()
    {
        RuleFor(c => c.Nome)
            .NotEmpty()
            .WithMessage(ResourceMensagensDeErro.USUARIO_NOME_VAZIO)
            .MaximumLength(200)
            .WithMessage(ResourceMensagensDeErro.USUARIO_NOME_MAXIMO200CARACTERES);

        RuleFor(c => c.Email)
            .NotEmpty()
            .WithMessage(ResourceMensagensDeErro.EMAIL_VAZIO);

        When(c => !string.IsNullOrWhiteSpace(c.Email), () =>
        {
            RuleFor(c => c.Email).EmailAddress().WithMessage(ResourceMensagensDeErro.USUARIO_EMAIL_INVALIDO);
        });
    }
}
