using AluraFlix.Application.UseCases.Handlers.Video.AdicionarVideo;
using Utilities.Command;
using FluentAssertions;
using AluraFlix.Exceptions;

namespace Validators.Test.Video;
public class AdicionarVideoValidatorTest
{
    [Fact]
    public void Sucesso()
    {
        var validator = new AdicionarVideoValidator();
        var command =  VideoCommandBuilder.AdicionarCommandBuild();

        var result = validator.Validate(command);

        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void ValidarErroTituloVazio()
    {
        var validator = new AdicionarVideoValidator();
        var command = VideoCommandBuilder.AdicionarCommandBuild();
        command.Titulo = string.Empty;

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And
            .Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.VIDEO_TITULO_VAZIO));
    }

    [Fact]
    public void ValidarErroTituloNoMaximo300Caracteres()
    {
        var validator = new AdicionarVideoValidator();
        var command = VideoCommandBuilder.AdicionarCommandBuild();
        var stringCom310Caracteres = string.Join("", Enumerable.Repeat("a", 310));
        command.Titulo = stringCom310Caracteres;

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And
            .Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.VIDEO_TITULO_MAXIMO300CARACTERES));
    }
    [Fact]
    public void ValidarErroDescricaoVazio()
    {
        var validator = new AdicionarVideoValidator();
        var command = VideoCommandBuilder.AdicionarCommandBuild();
        command.Descricao = string.Empty;

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And
            .Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.VIDEO_DESCRICAO_VAZIO));
    }

    [Fact]
    public void ValidarErroDescricaoNoMaximo600Caracteres()
    {
        var validator = new AdicionarVideoValidator();
        var command = VideoCommandBuilder.AdicionarCommandBuild();
        var stringCom610Caracteres = string.Join("", Enumerable.Repeat("a", 610));
        command.Descricao = stringCom610Caracteres;

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And
            .Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.VIDEO_DESCRICAO_MAXIMO600CARACTERES));
    }

    [Fact]
    public void ValidarErroURLVazio()
    {
        var validator = new AdicionarVideoValidator();
        var command = VideoCommandBuilder.AdicionarCommandBuild();
        command.URL = string.Empty;

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And
            .Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.VIDEO_URL_VAZIO));
    }

    [Fact]
    public void ValidarErroURLInvalido()
    {
        var validator = new AdicionarVideoValidator();
        var command = VideoCommandBuilder.AdicionarCommandBuild();
        command.URL = "https://cursosaluracombr/dashboard";

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And
            .Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.VIDEO_URL_INVALIDO));
    }
}
