using AluraFlix.Domain.Entities.Base;

namespace AluraFlix.Domain.Entities;
public class Video : BaseEntity
{
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string URL { get; set; } = string.Empty;

    public int CategoriaId { get; set; }

    public void Update(string titulo, string descricao, string url, int categoriaId)
    {
        Titulo = titulo;
        Descricao = descricao;
        URL = url;
        CategoriaId = categoriaId;
    }
}
