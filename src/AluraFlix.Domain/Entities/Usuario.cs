using AluraFlix.Domain.Entities.Base;

namespace AluraFlix.Domain.Entities;
public class Usuario : BaseEntity
{
    private const string ADMIN_ROLE = "ADMIN";
    private const string USER_ROLE = "USER";

    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Senha { get; private set; }
    public string Role { get; private set; }

    private Usuario(string nome, string email, string senha, string role)
    {
        Nome = nome;
        Email = email;
        Senha = senha;
        Role = role;
    }

    public static Usuario ContaAdministrador(string nome, string email, string senha)
    {
        var adm = new Usuario(nome, email, senha, ADMIN_ROLE);
        return adm;
    }

    public static Usuario ContaUsuario(string nome, string email, string senha)
    {
        var usuario = new Usuario(nome, email, senha, USER_ROLE);
        return usuario;
    }

}
