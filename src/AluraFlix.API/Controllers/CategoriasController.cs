using AluraFlix.API.Tools;
using AluraFlix.Application.UseCases.Commands;
using AluraFlix.Application.UseCases.Commands.Categoria;
using AluraFlix.Application.UseCases.Handlers.Categoria;
using AluraFlix.Application.UseCases.Handlers.Categoria.AtualizarCategoria;
using AluraFlix.Application.UseCases.Handlers.Categoria.CriarCategoria;
using AluraFlix.Application.UseCases.Results;
using AluraFlix.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AluraFlix.API.Controllers;

/// <response code="401">Essa operação é permitida apenas para usuarios autenticados.</response>
[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "ADMIN,USER")]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
public class CategoriasController : ControllerBase
{
    /// <summary>
    /// Adiciona uma categoria na base de dados.
    /// </summary>
    /// <response code="201">Retorna a categoria adicionada.</response>
    /// <response code="400">Provavelmente as propriedades estão inválido, Verifique a mensagem de erro.</response>
    /// <response code="403">Essa operação é permitida apenas para administrador(a)</response>
    [HttpPost]
    [Authorize("ADMIN")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Categoria))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RequestResult))]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> Add(
    [FromBody] CriarCategoriaCommand command,
    [FromServices] CriarCategoriaHandler handler)
    {
        return new ParseRequestResult().ParseToActionResult(await handler.Handle(command));
    }

    /// <summary>
    /// Retorna todas as categorias.
    /// </summary>
    /// <response code="200">Retorna lista de categorias.</response>
    /// <response code="204">Não foi encontrado nenhum categoria.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetAll(
    [FromServices] ObterTodasCategoriasHandler handler)
    {
        return new ParseRequestResult().ParseToActionResult(await handler.Handle(new NoParametersCommand()));
    }

    /// <summary>
    /// Retorna categoria por ID.
    /// </summary>
    /// <param name="id">Id da categoria</param>
    /// <response code="200">Retorna a categoria com o ID correspondente.</response>
    /// <response code="404">Categoria não foi encontrado.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(RequestResult))]
    public async Task<ActionResult> GetById(
    int id,
    [FromServices] ObterCategoriaPorIdHandler handler)
    {
        return new ParseRequestResult().ParseToActionResult(await handler.Handle(new GetByIdCommand { Id = id }));
    }

    /// <summary>
    /// Atualizar categoria.
    /// </summary>
    /// <param name="id">Id da categoria</param>
    /// <response code="200">Retorna a categoria com as propriedades atualizadas.</response>
    /// <response code="400">Provavelmente as propriedades estão inválidos, Verifique a mensagem de erro.</response>
    /// <response code="404">Categoria não foi encontrado.</response>
    /// <response code="403">Essa operação é permitida apenas para administrador(a)</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RequestResult))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(RequestResult))]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> Update(
    int id,
    [FromBody] AtualizarCategoriaCommand command,
    [FromServices] AtualizarCategoriaHandler handler)
    {
        command.SetId(id);
        return new ParseRequestResult().ParseToActionResult(await handler.Handle(command));
    }

    /// <summary>
    /// Deleta categoria por ID.
    /// </summary>
    /// <param name="id">Id da categoria</param>
    /// <response code="200">Categoria deletado com sucesso, retorna a categoria deletado.</response>
    /// <response code="404">Categoria não foi encontrado.</response>
    /// <response code="403">Essa operação é permitida apenas para administrador(a)</response>
    [HttpDelete("{id}")]
    [Authorize("ADMIN")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RequestResult))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(RequestResult))]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> Delete(
    int id,
    [FromServices] DeletarCategoriaHandler handler)
    {
        return new ParseRequestResult()
            .ParseToActionResult(await handler.Handle(new DeletarCategoriaCommand { Id = id }));
    }

    /// <summary>
    /// Retorna todas os video de uma categoria escolhida.
    /// </summary>
    /// <param name="id">Id da categoria</param>
    /// <response code="200">Retorna lista de videos filtrado por apenas videos da categoria escolhida.</response>
    /// <response code="204">Não foi encontrado nenhum video.</response>
    [HttpGet("{id}/videos")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<ActionResult> GetByCategoria(
    int id,
    [FromQuery] ObterVideosPorCategoriaCommand command,
    [FromServices] ObterVideosPorCategoriaHandler handler)
    {
        command.Id = id;
        return new ParseRequestResult().ParseToActionResult(await handler.Handle(command), Response);
    }
}
