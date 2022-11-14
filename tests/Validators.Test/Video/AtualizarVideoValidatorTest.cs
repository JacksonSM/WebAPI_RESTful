using AluraFlix.Application.UseCases.Handlers.Video.AtualizarVideo;
using AluraFlix.Exceptions;
using Utilities.Command;

namespace Validators.Test.Video;
public class AtualizarVideoValidatorTest
{
    [Fact]
    public void Sucesso()
    {
        var validator = new AtualizarVideoValidator();
        var command = VideoCommandBuilder.AtualizarCommandBuild();

        var result = validator.Validate(command);

        result.IsValid.Should().BeTrue();
    }
    [Fact]
    public void ValidarErroTituloVazio()
    {
        var validator = new AtualizarVideoValidator();
        var command = VideoCommandBuilder.AtualizarCommandBuild();
        command.Titulo = string.Empty;

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And
            .Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.VIDEO_TITULO_VAZIO));
    }

    [Fact]
    public void ValidarErroTituloNoMaximo300Caracteres()
    {
        var validator = new AtualizarVideoValidator();
        var command = VideoCommandBuilder.AtualizarCommandBuild();
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
        var validator = new AtualizarVideoValidator();
        var command = VideoCommandBuilder.AtualizarCommandBuild();
        command.Descricao = string.Empty;

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And
            .Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.VIDEO_DESCRICAO_VAZIO));
    }

    [Fact]
    public void ValidarErroDescricaoNoMaximo600Caracteres()
    {
        var validator = new AtualizarVideoValidator();
        var command = VideoCommandBuilder.AtualizarCommandBuild();
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
        var validator = new AtualizarVideoValidator();
        var command = VideoCommandBuilder.AtualizarCommandBuild();
        command.URL = string.Empty;

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And
            .Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.VIDEO_URL_VAZIO));
    }

    [Fact]
    public void ValidarErroURLInvalido()
    {
        var validator = new AtualizarVideoValidator();
        var command = VideoCommandBuilder.AtualizarCommandBuild();
        command.URL = "https://cursosaluracombr/dashboard";

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And
            .Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.VIDEO_URL_INVALIDO));
    }
}
