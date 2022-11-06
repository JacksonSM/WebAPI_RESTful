using AluraFlix.Domain.Entities;
using AluraFlix.Domain.Interfaces;
using AluraFlix.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AluraFlix.Infrastructure.Repositories;
public class CategoriaRepository : ICategoriaRepository
{
    private readonly AluraFlixDbContext _context;

    public CategoriaRepository(AluraFlixDbContext context)
    {
        _context = context;
    }

    public async Task<Categoria> AddAsync(Categoria categoria) 
    {
        await _context.AddAsync(categoria);
        return categoria;
    }

    public async Task<bool> ExistById(int id) => 
        await _context.Categorias.AnyAsync(c => c.Id == id);

    public async Task<IEnumerable<Categoria>> GetAllAsync() =>
        await _context.Categorias.ToArrayAsync();
}
