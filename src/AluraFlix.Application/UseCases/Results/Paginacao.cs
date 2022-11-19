

using Newtonsoft.Json;

namespace AluraFlix.Application.UseCases.Results;

public class PaginacaoHeader
{
    [JsonIgnore]
    public string Chave { get; private set; } 
    public int PaginaAtual { get; set; }
    public int ItensPorPagina { get; set; }
    public int TotalItens { get; set; }
    public int TotalPaginas { get; set; }

    public PaginacaoHeader(int paginaAtual, int itensPorPagina, int totalItens)
    {
        PaginaAtual = paginaAtual;
        ItensPorPagina = itensPorPagina;
        TotalItens = totalItens;
        TotalPaginas = (totalItens / itensPorPagina);
        Chave = "X-Pagination";
    }
}
