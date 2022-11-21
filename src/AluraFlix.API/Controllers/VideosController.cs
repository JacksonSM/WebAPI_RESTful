using AluraFlix.API.Tools;
using AluraFlix.Application.UseCases.Commands;
using AluraFlix.Application.UseCases.Commands.Video;
using AluraFlix.Application.UseCases.Handlers.Video;
using AluraFlix.Application.UseCases.Handlers.Video.AdicionarVideo;
using AluraFlix.Application.UseCases.Handlers.Video.AtualizarVideo;
using AluraFlix.Application.UseCases.Results;
using AluraFlix.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AluraFlix.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "ADMIN,USER")]
public class VideosController : ControllerBase
{
    /// <summary>
    /// Adiciona um video na base de dados.
    /// </summary>
    /// <response code="201">Retorna o video adicionado.</response>
    /// <response code="400">Provavelmente as propriedades estão inválido, Verifique a mensagem de erro.</response>
    /// <response code="403">Essa operação é permitida apenas para administrador(a)</response>
    /// <response code="401">Essa operação é permitida apenas para usuarios autenticados.</response>
    [HttpPost]
    [Authorize("ADMIN")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RequestResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RequestResult))]
    public async Task<ActionResult> Add(
    [FromBody] AdicionarVideoCommand command,
    [FromServices] AdicionarVideoHandler handler)
    {
        return new ParseRequestResult().ParseToActionResult(await handler.Handle(command));
    }

    /// <summary>
    /// Retorna todos os videos com ou sem paginação, pesquisa por titulo opcional.
    /// </summary>
    /// <remarks>As informaçoes da paginação estão no header com a chave: "X-Pagination"</remarks>
    /// <response code="200">Retorna lista de videos.</response>
    /// <response code="204">Não foi encontrado nenhum video.</response>
    /// <response code="401">Essa operação é permitida apenas para usuarios autenticados.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RequestResult))]
    public async Task<ActionResult> GetAll(
    [FromQuery] ObterTodosVideosCommand command,
    [FromServices] ObterTodosVideosHandler handler)
    {
        return new ParseRequestResult().ParseToActionResult(await handler.Handle(command), Response);
    }

    /// <summary>
    /// Retorna video por ID.
    /// </summary>
    /// <param name="id">Id do video</param>
    /// <response code="200">Retorna o video com o ID correspondente.</response>
    /// <response code="404">Video não foi encontrado.</response>
    /// <response code="401">Essa operação é permitida apenas para usuarios autenticados.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RequestResult))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(RequestResult))]
    public async Task<ActionResult> GetById(
    int id,
    [FromServices] ObterVideoPorIdHandler handler)
    {
        return new ParseRequestResult().ParseToActionResult(await handler.Handle(new GetByIdCommand { Id = id}));
    }

    /// <summary>
    /// Atualizar video.
    /// </summary>
    /// <param name="id">Id do video</param>
    /// <response code="200">Retorna o video com as propriedades atualizadas.</response>
    /// <response code="400">Provavelmente as propriedades estão inválidos, Verifique a mensagem de erro.</response>
    /// <response code="404">Video não foi encontrado.</response>
    /// <response code="403">Essa operação é permitida apenas para administrador(a)</response>
    /// <response code="401">Essa operação é permitida apenas para usuarios autenticados.</response>
    [HttpPut("{id}")]
    [Authorize("ADMIN")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Video[]))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RequestResult))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(RequestResult))]
    public async Task<ActionResult> Update(
    int id,
    [FromBody] AtualizarVideoCommand command,
    [FromServices] AtualizarVideoHandler handler)
    {
        command.SetId(id);
        return new ParseRequestResult().ParseToActionResult(await handler.Handle(command));
    }

    /// <summary>
    /// Deleta video por ID.
    /// </summary>
    /// <param name="id">Id do video</param>
    /// <response code="200">Video deletado com sucesso, retorna o video deletado.</response>
    /// <response code="404">Video não foi encontrado.</response>
    /// <response code="403">Essa operação é permitida apenas para administrador(a)</response>
    /// <response code="401">Essa operação é permitida apenas para usuarios autenticados.</response>
    [HttpDelete("{id}")]
    [Authorize("ADMIN")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RequestResult))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(RequestResult))]
    public async Task<ActionResult> Delete(
    int id,
    [FromServices] DeletarVideoHandler handler)
    {
        return new ParseRequestResult()
            .ParseToActionResult(await handler.Handle(new DeletarVideoCommand { Id = id}));
    }

    /// <summary>
    /// Retorna todos os 10 ultimos videos com ou sem paginação e sem a necessidade de autenticação.
    /// </summary>
    /// <remarks>As informaçoes da paginação estão no header com a chave: "X-Pagination"</remarks>
    /// <response code="200">Retorna lista de videos.</response>
    /// <response code="204">Não foi encontrado nenhum video.</response>
    [HttpGet("free")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RequestResult))]
    public async Task<ActionResult> GetAllFree(
    [FromQuery] ObterTodosVideosFreeCommand command,
    [FromServices] ObterTodosVideosFreeHandler handler)
    {
        return new ParseRequestResult().ParseToActionResult(await handler.Handle(command), Response);
    }
}
