namespace AluraFlix.Application.UseCases.Commands.Video;
public abstract class VideoCommand : ICommand
{
    public int Id { get; private set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string URL { get; set; } = string.Empty;
    public int CategoriaId { get; set; }

    public void SetId(int id)
    {
        Id = id;
    }
}
