using AluraFlix.Application.UseCases.Commands.Categoria;
using Bogus;

namespace Utilities.Command;
public class CategoriaCommandBuilder
{
    public static CriarCategoriaCommand CriarCommandBuild()
    {
        return new Faker<CriarCategoriaCommand>()
            .RuleFor(c => c.Titulo, f => f.Random.Words(6))
            .RuleFor(c => c.Cor, f => f.Internet.Color());
    }
    public static AtualizarCategoriaCommand AtualizarCommandBuild()
    {
        return new Faker<AtualizarCategoriaCommand>()
            .RuleFor(c => c.Titulo, f => f.Random.Words(6))
            .RuleFor(c => c.Cor, f => f.Internet.Color());
    }
}
