using AluraFlix.API.Tools;
using AluraFlix.Application.UseCases.Commands.Video;
using AluraFlix.Application.UseCases.Handlers.Video.AdicionarVideo;
using AluraFlix.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AluraFlix.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class VideoController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Video))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Add(
    [FromBody] AdicionarVideoCommand command,
    [FromServices] AdicionarVideoHandler handler)
    {
        return new ParseRequestResult().ParseToActionResult(await handler.Handle(command));
    }
}
