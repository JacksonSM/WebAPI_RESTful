namespace AluraFlix.Application.UseCases.Commands.Video;
public class GetByQueryCommand : PaginacaoCommand
{
    public string? Search { get; set; }
}
