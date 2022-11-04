namespace AluraFlix.Application.UseCases.Commands.Video;
public class AdicionarVideoCommand : ICommand
{
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string URL { get; set; } = string.Empty;
}
