using System.Text.Json.Serialization;

namespace AluraFlix.Application.UseCases.Results
{
    public class RequestResult
    {
        [JsonIgnore]
        public int StatusCode { get; private set; }
        public string Message { get; private set; }
        public object Data { get; private set; }

        public RequestResult Ok(object data, string message = "Requisição realizada com sucesso")
        {
            StatusCode = 200;
            Message = message;
            Data = data;
            return this;
        }
        public RequestResult Created(object data)
        {
            StatusCode = 201;
            Message = "Recurso adicionado com sucesso";
            Data = data;
            return this;
        }

        public RequestResult BadRequest(string detail, object data = null)
        {
            StatusCode = 400;
            Message = $"Falha ao realizar a requisição. Mais detalhes: {detail}";
            Data = data;
            return this;
        }
        public RequestResult NoContext()
        {
            StatusCode = 204;
            Message = $"Sem conteúdo";
            return this;
        }
        public RequestResult NotFound()
        {
            StatusCode = 404;
            Message = $"Recurso não encontrado.";
            return this;
        }
    }
}