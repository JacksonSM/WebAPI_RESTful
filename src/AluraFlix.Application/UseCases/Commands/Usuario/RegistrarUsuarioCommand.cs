namespace AluraFlix.Application.UseCases.Commands.Usuario;
public class RegistrarUsuarioCommand :  ICommand
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
}
