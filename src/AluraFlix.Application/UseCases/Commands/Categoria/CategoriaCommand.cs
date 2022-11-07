namespace AluraFlix.Application.UseCases.Commands.Categoria;
public class CategoriaCommand : ICommand
{
    public int Id { get; private set; }
    public string Titulo { get; set; } = string.Empty;
    public string Cor { get; set; } = string.Empty;

    public void SetId(int id)
    {
        Id = id;
    }
}
