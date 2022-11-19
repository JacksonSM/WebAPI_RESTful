namespace AluraFlix.Application.UseCases.Commands;
public abstract class PaginacaoCommand : ICommand
{
    public int? paginaAtual { get; set; }
    public int? itensPorPagina { get; set; }
}
