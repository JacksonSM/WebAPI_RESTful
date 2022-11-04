using AluraFlix.Domain.Interfaces;
using AluraFlix.Infrastructure.Context;

namespace AluraFlix.Infrastructure.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly AluraFlixDbContext _context;

    public UnitOfWork(AluraFlixDbContext context)
    {
        _context = context;
    }

    public async Task CommitAsync()
        => await _context.SaveChangesAsync();
}
