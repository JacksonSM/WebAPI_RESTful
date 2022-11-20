using AluraFlix.API.Tools;
using AluraFlix.Application.UseCases.Commands.Usuario;
using AluraFlix.Application.UseCases.Handlers.Usuario;
using AluraFlix.Application.UseCases.Results;
using Microsoft.AspNetCore.Mvc;

namespace AluraFlix.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(LoginResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Login(
        [FromBody] UsuarioLoginCommand command,
        [FromServices] UsuarioLoginHandler handler)
    {
        return new ParseRequestResult().ParseToActionResult(await handler.Handle(command));
    }
}
