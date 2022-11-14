using AluraFlix.Application.UseCases.Handlers.Categoria.CriarCategoria;
using AluraFlix.Exceptions;
using Utilities.Command;

namespace Validators.Test.Categoria;

public class CriarCategoriaValidatorTest
{
    [Fact]
    public void Sucesso()
    {
        var validator = new CriarCategoriaValidator();
        var command = CategoriaCommandBuilder.CriarCommandBuild();

        var result = validator.Validate(command);

        result.IsValid.Should().BeTrue();
    }
    [Fact]
    public void ValidarErroTituloVazio()
    {
        var validator = new CriarCategoriaValidator();
        var command = CategoriaCommandBuilder.CriarCommandBuild();
        command.Titulo = string.Empty;

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And
            .Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.CATEGORIA_TITULO_VAZIO));
    }


    [Fact]
    public void ValidarErroTituloNoMaximo200Caracteres()
    {
        var validator = new CriarCategoriaValidator();
        var command = CategoriaCommandBuilder.CriarCommandBuild();
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
        var validator = new CriarCategoriaValidator();
        var command = CategoriaCommandBuilder.CriarCommandBuild();
        command.Cor = string.Empty;

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And
            .Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.CATEGORIA_COR_VAZIO));
    }


    [Fact]
    public void ValidarErroCorNoMaximo15Caracteres()
    {
        var validator = new CriarCategoriaValidator();
        var command = CategoriaCommandBuilder.CriarCommandBuild();
        var stringCom20Caracteres = string.Join("", Enumerable.Repeat("a", 20));
        command.Cor = stringCom20Caracteres;

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should()
            .Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.CATEGORIA_COR_INVALIDO)).And
            .Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.CATEGORIA_COR_MAXIMO15CARACTERES));
    }

    [Theory]
    [InlineData("$x9B87")]
    [InlineData("FFFFFF")]
    [InlineData("#04835L")]
    [InlineData("#x987dc")]
    public void ValidarErroCorInvalido(string cor)
    {
        var validator = new CriarCategoriaValidator();
        var command = CategoriaCommandBuilder.CriarCommandBuild();
        var stringCom20Caracteres = string.Join("", Enumerable.Repeat("a", 20));
        command.Cor = cor;

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And
            .Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.CATEGORIA_COR_INVALIDO));
    }
}
