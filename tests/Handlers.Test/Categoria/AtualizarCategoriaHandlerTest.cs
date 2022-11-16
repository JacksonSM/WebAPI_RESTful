using AluraFlix.Application.UseCases.Handlers.Categoria.AtualizarCategoria;
using AluraFlix.Domain.Interfaces;
using Moq;
using Utilities.Command;
using Utilities.Repositories;

namespace Handlers.Test.Categoria;
public class AtualizarCategoriaHandlerTest
{
    [Fact]
    public async Task DadosEntradaDevemChagarAoRepositorio()
    {
        var mockCommand = CategoriaCommandBuilder.AtualizarCommandBuild();
        var mockCategoria = new AluraFlix.Domain.Entities.Categoria
        {
            Id = mockCommand.Id,
            Titulo = "Back-end",
            Cor = "#FFFFFF"
        };

        var mockRepo = new Mock<ICategoriaRepository>();
        mockRepo.Setup(m => m.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(mockCategoria);

        var mockUow = UnitOfWorkBuilder.Instance().Build();

        var handler = new AtualizarCategoriaHandler
            (
                categoriaRepository: mockRepo.Object,
                uow: mockUow
            );

        var response = await handler.Handle(mockCommand);


        response.Should().NotBeNull();
        response.StatusCode.Should().Be(200);

        mockRepo.Verify(m => m.Update
        (
            It.Is<AluraFlix.Domain.Entities.Categoria>
                (p => p.Id.Equals(mockCommand.Id) &&
                 p.Titulo.Equals(mockCommand.Titulo) &&
                 p.Cor.Equals(mockCommand.Cor))
        ));
    }

    [Fact]
    public async Task DadosEntradaDevemSerIguaisAoDeSaida()
    {
        var mockCommand = CategoriaCommandBuilder.AtualizarCommandBuild();
        var mockCategoria = new AluraFlix.Domain.Entities.Categoria
        {
            Id = mockCommand.Id,
            Titulo = "Front-end",
            Cor = "#000000"
        };
        var mockRepo = new Mock<ICategoriaRepository>();
        mockRepo.Setup(m => m.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(mockCategoria);

        var mockUow = UnitOfWorkBuilder.Instance().Build();

        var handler = new AtualizarCategoriaHandler
            (
                categoriaRepository: mockRepo.Object,
                uow: mockUow
            );


        var response = await handler.Handle(mockCommand);

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(200);

        var dataResponse = response.Data as AluraFlix.Domain.Entities.Categoria;
        dataResponse.Titulo.Should().Be(mockCommand.Titulo);
        dataResponse.Cor.Should().Be(mockCommand.Cor);
    }
}
