namespace AluraFlix.Application.UseCases.Commands.Video;
public class GetByQueryCommand : ICommand
{
    public string? Search { get; set; }
}
