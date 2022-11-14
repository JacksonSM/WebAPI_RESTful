using AluraFlix.Application.UseCases.Commands.Video;
using FluentValidation;

namespace AluraFlix.Application.UseCases.Handlers.Video.AdicionarVideo;
public class AdicionarVideoValidator : AbstractValidator<AdicionarVideoCommand>
{
    public AdicionarVideoValidator()
    {
        RuleFor(x => x).SetValidator(new VideoValidator());
    }
}
