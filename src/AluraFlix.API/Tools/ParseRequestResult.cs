using AluraFlix.Application.UseCases.Results;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AluraFlix.API.Tools
{
    public class ParseRequestResult : Controller
    {
        public ActionResult ParseToActionResult(RequestResult request)
        {
            switch (request.StatusCode)
            {
                case (int)HttpStatusCode.OK:
                    return Ok(request);
                case (int)HttpStatusCode.Created:
                    return Created(string.Empty, request);
                case (int)HttpStatusCode.NoContent:
                    return NoContent();
                case (int)HttpStatusCode.NotFound:
                    return NotFound(request);
                case (int)HttpStatusCode.BadRequest:
                    return BadRequest(request);
                default:
                    return BadRequest(request);
            }
        }
    }
}