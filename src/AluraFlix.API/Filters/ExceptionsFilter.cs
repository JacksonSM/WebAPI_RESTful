using AluraFlix.API.Tools;
using AluraFlix.Application.UseCases.Results;
using AluraFlix.Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace AluraFlix.API.Filters;

public class ExceptionsFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is AluraFlixException)
        {
            TratarAluraFlixException(context);
        }
        else
        {
            LancarErroDesconhecido(context);
        }
    }

    private static void LancarErroDesconhecido(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new { MensagemErro = "Erro desconhecido"});
    }

    private static void TratarAluraFlixException(ExceptionContext context)
    {
        if (context.Exception is ErrosDeValidacaoException)
        {
            TratarErrosDeValidacaoException(context);
        }
    }

    private static void TratarErrosDeValidacaoException(ExceptionContext context)
    {
        var erroDeValidacaoException = context.Exception as ErrosDeValidacaoException;
        context.Result = new ParseRequestResult()
            .ParseToActionResult(new RequestResult()
            .BadRequest("Erros de validaçãoes", erroDeValidacaoException.MensagensDeErro));
    }
}
