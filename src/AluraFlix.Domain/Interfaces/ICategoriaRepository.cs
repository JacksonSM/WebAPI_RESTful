using AluraFlix.Domain.Entities;

namespace AluraFlix.Domain.Interfaces;
public interface ICategoriaRepository
{
    Task<Categoria> AddAsync(Categoria categoria);
    Task<bool> ExistById(int id);
}
