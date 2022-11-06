namespace AluraFlix.Application.UseCases.Commands.Categoria;
public class CategoriaCommand : ICommand
{
    public string Titulo { get; set; } = string.Empty;
    public string Cor { get; set; } = string.Empty;
}
