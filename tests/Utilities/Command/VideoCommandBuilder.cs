using AluraFlix.Application.UseCases.Commands;
using AluraFlix.Application.UseCases.Commands.Video;
using Bogus;

namespace Utilities.Command;
public class VideoCommandBuilder
{
    public static AdicionarVideoCommand AdicionarCommandBuild()
    {
        return new Faker<AdicionarVideoCommand>()
            .RuleFor(c => c.Titulo, f => f.Random.Words(6))
            .RuleFor(c => c.Descricao, f => f.Lorem.Paragraph(1))
            .RuleFor(c => c.URL, f => f.Internet.Url())
            .RuleFor(c => c.CategoriaId, f => f.Random.Int(1,200));
    }
    public static AtualizarVideoCommand AtualizarCommandBuild()
    {
        return new Faker<AtualizarVideoCommand>()
            .RuleFor(c => c.Titulo, f => f.Random.Words(6))
            .RuleFor(c => c.Descricao, f => f.Lorem.Paragraph(1))
            .RuleFor(c => c.URL, f => f.Internet.Url())
            .RuleFor(c => c.CategoriaId, f => f.Random.Int(1, 200));
    }

}
