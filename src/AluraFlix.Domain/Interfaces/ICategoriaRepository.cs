using AluraFlix.Domain.Entities;

namespace AluraFlix.Domain.Interfaces;
public interface ICategoriaRepository
{
    Task<Categoria> AddAsync(Categoria categoria);
    Task<IEnumerable<Categoria>> GetAllAsync();
    Task<bool> ExistById(int id);
    Task<Categoria> GetByIdAsync(int id);
    void Update(Categoria categoria);
    void Remove(Categoria video);
}
