using AluraFlix.API.Tools;
using AluraFlix.Application.UseCases.Commands.Categoria;
using AluraFlix.Application.UseCases.Handlers.Categoria.CriarCategoria;
using AluraFlix.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AluraFlix.API.Controllers;
[Route("api/[controller]")]
[ApiController]

public class CategoriasController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Categoria))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Add(
    [FromBody] CriarCategoriaCommand command,
    [FromServices] CriarCategoriaHandler handler)
    {
        return new ParseRequestResult().ParseToActionResult(await handler.Handle(command));
    }
}
