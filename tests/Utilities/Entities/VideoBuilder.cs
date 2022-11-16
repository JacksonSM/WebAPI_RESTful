using AluraFlix.Domain.Entities;
using Bogus;

namespace Utilities.Entities;
public class VideoBuilder
{
    public static Video Build()
    {
        return new Faker<Video>()
            .RuleFor(c => c.Titulo, f => f.Random.Words(6))
            .RuleFor(c => c.Descricao, f => f.Lorem.Paragraph(1))
            .RuleFor(c => c.URL, f => f.Internet.Url())
            .RuleFor(c => c.CategoriaId, f => f.Random.Int(1, 200));
    }
}
