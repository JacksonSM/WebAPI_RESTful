using AluraFlix.API.Tools;
using AluraFlix.Application.UseCases.Commands;
using AluraFlix.Application.UseCases.Commands.Categoria;
using AluraFlix.Application.UseCases.Handlers.Categoria;
using AluraFlix.Application.UseCases.Handlers.Categoria.AtualizarCategoria;
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

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetAll(
    [FromServices] ObterTodasCategoriasHandler handler)
    {
        return new ParseRequestResult().ParseToActionResult(await handler.Handle(new NoParametersCommand()));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<ActionResult> GetById(
    int id,
    [FromServices] ObterCategoriaPorIdHandler handler)
    {
        return new ParseRequestResult().ParseToActionResult(await handler.Handle(new GetByIdCommand { Id = id }));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<ActionResult> GetById(
    int id,
    [FromBody] AtualizarCategoriaCommand command,
    [FromServices] AtualizarCategoriaHandler handler)
    {
        command.SetId(id);
        return new ParseRequestResult().ParseToActionResult(await handler.Handle(command));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<ActionResult> Delete(
    int id,
    [FromServices] DeletarCategoriaHandler handler)
    {
        return new ParseRequestResult()
            .ParseToActionResult(await handler.Handle(new DeletarCategoriaCommand { Id = id }));
    }

    [HttpGet("{id}/videos")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<ActionResult> GetByCategoria(
    int id,
    [FromServices] ObterVideosPorCategoriaHandler handler)
    {
        return new ParseRequestResult().ParseToActionResult(await handler.Handle(new GetByIdCommand { Id = id }));
    }
}
