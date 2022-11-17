using AluraFlix.Domain.Entities;
using AluraFlix.Domain.Interfaces;
using AluraFlix.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AluraFlix.Infrastructure.Repositories;
public class UsuarioRepository : IUsuarioRepository
{
    private readonly AluraFlixDbContext _context;

    public UsuarioRepository(AluraFlixDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Usuario usuario) =>
        await _context.Usuarios.AddAsync(usuario);

    public async Task<bool> ExistEmailAsync(string email) =>
        await _context.Usuarios.AnyAsync(c => c.Email.Equals(email));
}
