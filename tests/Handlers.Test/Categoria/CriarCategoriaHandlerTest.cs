using AluraFlix.Application.UseCases.Handlers.Categoria.CriarCategoria;
using AluraFlix.Domain.Interfaces;
using Moq;
using Utilities.Command;
using Utilities.Repositories;
using Utilities.Tools;

namespace Handlers.Test.Categoria;
public class CriarCategoriaHandlerTest
{
    [Fact]
    public async Task DadosEntradaDevemChagarAoRepositorio()
    {
        var mockCommand = CategoriaCommandBuilder.CriarCommandBuild();
        var mockRepo = new Mock<ICategoriaRepository>();
        var mockUow = UnitOfWorkBuilder.Instance().Build();
        var mockMapper = MapperBuilder.Instance();

        var handler = new CriarCategoriaHandler
            (
                categoriaRepository: mockRepo.Object,
                uow: mockUow,
                mapper: mockMapper
            );

        var response = await handler.Handle(mockCommand);


        response.Should().NotBeNull();
        response.StatusCode.Should().Be(201);

        mockRepo.Verify(m => m.AddAsync
            (
                It.Is<AluraFlix.Domain.Entities.Categoria>
                    (p => p.Titulo.Equals(mockCommand.Titulo) &&
                     p.Cor.Equals(mockCommand.Cor))
            ));
    }

    [Fact]
    public async Task DadosEntradaDevemSerIguaisAoDeSaida()
    {
        var mockCommand = CategoriaCommandBuilder.CriarCommandBuild();

        var mockRepo = new Mock<ICategoriaRepository>();

        var mockUow = UnitOfWorkBuilder.Instance().Build();
        var mockMapper = MapperBuilder.Instance();

        var handler = new CriarCategoriaHandler
            (
                categoriaRepository: mockRepo.Object,
                uow: mockUow,
                mapper: mockMapper
            );


        var response = await handler.Handle(mockCommand);

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(201);

        var dataResponse = response.Data as AluraFlix.Domain.Entities.Categoria;
        dataResponse.Titulo.Should().Be(mockCommand.Titulo);
        dataResponse.Cor.Should().Be(mockCommand.Cor);
    }
}
