using AluraFlix.Application.UseCases.Commands.Video;
using AluraFlix.Application.UseCases.Handlers.Video.AdicionarVideo;
using FluentValidation;

namespace AluraFlix.Application.UseCases.Handlers.Video.AtualizarVideo;
internal class AtualizarVideoValidator : AbstractValidator<AtualizarVideoCommand>
{
    public AtualizarVideoValidator()
    {
        RuleFor(x => x).SetValidator(new VideoValidator());
    }
}
