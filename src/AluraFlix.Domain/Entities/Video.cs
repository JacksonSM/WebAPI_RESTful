using AluraFlix.Domain.Entities.Base;

namespace AluraFlix.Domain.Entities;
public class Video : BaseEntity
{
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string URL { get; set; } = string.Empty;

    public void Update(string titulo, string descricao, string uRL)
    {
        Titulo = titulo;
        Descricao = descricao;
        URL = uRL;
    }
}
