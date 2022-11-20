using AluraFlix.API.Tools;
using AluraFlix.Application.UseCases.Commands.Usuario;
using AluraFlix.Application.UseCases.Handlers.Usuario;
using AluraFlix.Application.UseCases.Results;
using Microsoft.AspNetCore.Mvc;

namespace AluraFlix.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    /// <summary>
    /// Atenticação de usuario.
    /// </summary>
    /// <response code="200">Retorna o nome do usuario e um token</response>
    /// <response code="400">Provavelmente os campos estão errado, Verifique a mensagem de erro.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RequestResult))]
    public async Task<ActionResult> Login(
        [FromBody] UsuarioLoginCommand command,
        [FromServices] UsuarioLoginHandler handler)
    {
        return new ParseRequestResult().ParseToActionResult(await handler.Handle(command));
    }
}
