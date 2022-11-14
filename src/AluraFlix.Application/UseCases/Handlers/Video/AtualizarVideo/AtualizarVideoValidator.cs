using AluraFlix.Application.UseCases.Commands.Video;
using FluentValidation;

namespace AluraFlix.Application.UseCases.Handlers.Video.AtualizarVideo;
public class AtualizarVideoValidator : AbstractValidator<AtualizarVideoCommand>
{
    public AtualizarVideoValidator()
    {
        RuleFor(x => x).SetValidator(new VideoValidator());
    }
}
