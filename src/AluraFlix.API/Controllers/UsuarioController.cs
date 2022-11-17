using AluraFlix.API.Tools;
using AluraFlix.Application.UseCases.Commands.Usuario;
using AluraFlix.Application.UseCases.Handlers.Usuario.Registrar;
using AluraFlix.Application.UseCases.Results;
using Microsoft.AspNetCore.Mvc;

namespace AluraFlix.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RegistrarUsuarioResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Add(
    [FromBody] RegistrarUsuarioCommand command,
    [FromServices] RegistrarUsuarioHandler handler)
    {
        return new ParseRequestResult().ParseToActionResult(await handler.Handle(command));
    }
}
