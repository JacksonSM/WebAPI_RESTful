using AluraFlix.Domain.Entities.Base;

namespace AluraFlix.Domain.Entities;
public class Categoria : BaseEntity
{
    public string Titulo { get; set; } = string.Empty;
    public string Cor { get; set; } = string.Empty;

    public List<Video> Videos { get; set; }
}
