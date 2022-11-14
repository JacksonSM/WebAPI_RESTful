using AluraFlix.Application.UseCases.Handlers.Categoria.AtualizarCategoria;
using AluraFlix.Exceptions;
using Utilities.Command;

namespace Validators.Test.Categoria;
public class AtualizarCategoriaValidatorTest
{
    [Fact]
    public void Sucesso()
    {
        var validator = new AtualizarCategoriaValidator();
        var command = CategoriaCommandBuilder.AtualizarCommandBuild();

        var result = validator.Validate(command);

        result.IsValid.Should().BeTrue();
    }
    [Fact]
    public void ValidarErroTituloVazio()
    {
        var validator = new AtualizarCategoriaValidator();
        var command = CategoriaCommandBuilder.AtualizarCommandBuild();
        command.Titulo = string.Empty;

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And
            .Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.CATEGORIA_TITULO_VAZIO));
    }


    [Fact]
    public void ValidarErroTituloNoMaximo200Caracteres()
    {
        var validator = new AtualizarCategoriaValidator();
        var command = CategoriaCommandBuilder.AtualizarCommandBuild();
        var stringCom205Caracteres = string.Join("", Enumerable.Repeat("a", 205));
        command.Titulo = stringCom205Caracteres;

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And
            .Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.CATEGORIA_TITULO_MAXIMO200CARACTERES));
    }

    [Fact]
    public void ValidarErroCorVazio()
    {
        var validator = new AtualizarCategoriaValidator();
        var command = CategoriaCommandBuilder.AtualizarCommandBuild();
        command.Cor = string.Empty;

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And
            .Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.CATEGORIA_COR_VAZIO));
    }


    [Fact]
    public void ValidarErroCorNoMaximo15Caracteres()
    {
        var validator = new AtualizarCategoriaValidator();
        var command = CategoriaCommandBuilder.AtualizarCommandBuild();
        var stringCom20Caracteres = string.Join("", Enumerable.Repeat("a", 20));
        command.Cor = stringCom20Caracteres;

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should()
            .Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.CATEGORIA_COR_INVALIDO)).And
            .Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.CATEGORIA_COR_MAXIMO15CARACTERES));
    }

    [Theory]
    [InlineData("@FF3902")]
    [InlineData("*000000")]
    [InlineData("048353")]
    [InlineData("#x987dc")]
    public void ValidarErroCorInvalido(string cor)
    {
        var validator = new AtualizarCategoriaValidator();
        var command = CategoriaCommandBuilder.AtualizarCommandBuild();
        var stringCom20Caracteres = string.Join("", Enumerable.Repeat("a", 20));
        command.Cor = cor;

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And
            .Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.CATEGORIA_COR_INVALIDO));
    }
}
