namespace AluraFlix.Application.UseCases.Commands.Usuario;
public class UsuarioLoginCommand : ICommand
{
    public string Email { get; set; }
    public string Senha { get; set; }
}
