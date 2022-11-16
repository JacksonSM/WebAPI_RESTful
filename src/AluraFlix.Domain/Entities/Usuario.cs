using AluraFlix.Domain.Entities.Base;

namespace AluraFlix.Domain.Entities;
public class Usuario : BaseEntity
{
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Senha { get; private set; }

    public Usuario(string nome, string email, string senha)
    {
        Nome = nome;
        Email = email;
        Senha = senha;
    }
}
