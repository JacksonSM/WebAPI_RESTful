using AluraFlix.Domain.Entities;

namespace AluraFlix.Domain.Interfaces;
public interface ICategoriaRepository
{
    Task<Categoria> AddAsync(Categoria categoria);
    Task<IEnumerable<Categoria>> GetAllAsync();
    Task<bool> ExistById(int id);
}
