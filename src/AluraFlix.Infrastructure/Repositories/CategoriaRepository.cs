using AluraFlix.Domain.Entities;
using AluraFlix.Domain.Interfaces;
using AluraFlix.Infrastructure.Context;

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

}
