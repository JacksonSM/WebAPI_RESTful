using AluraFlix.Application.UseCases.Commands.Video;
using AluraFlix.Exceptions;
using FluentValidation;

namespace AluraFlix.Application.UseCases.Handlers.Video.AdicionarVideo;
public class VideoValidator : AbstractValidator<VideoCommand>
{
    public VideoValidator()
    {
        RuleFor(c => c.Titulo)
            .NotEmpty()
            .WithMessage(ResourceMensagensDeErro.VIDEO_TITULO_VAZIO)
            .MaximumLength(300)
            .WithMessage(ResourceMensagensDeErro.VIDEO_TITULO_MAXIMO300CARACTERES);

        RuleFor(c => c.Descricao)
            .NotEmpty()
            .WithMessage(ResourceMensagensDeErro.VIDEO_DESCRICAO_VAZIO)
            .MaximumLength(600)
            .WithMessage(ResourceMensagensDeErro.VIDEO_DESCRICAO_MAXIMO600CARACTERES);

        RuleFor(c => c.URL)
            .NotEmpty()
            .WithMessage(ResourceMensagensDeErro.VIDEO_URL_VAZIO);
    }
}
