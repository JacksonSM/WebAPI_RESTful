using AluraFlix.Domain.Entities;
using AluraFlix.Domain.Interfaces;
using AluraFlix.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AluraFlix.Infrastructure.Repositories;
public class VideoRepository : IVideosRepository
{
    private readonly AluraFlixDbContext _context;

    public VideoRepository(AluraFlixDbContext context)
    {
        _context = context;
    }

    public async Task<Video> AddAsync(Video video)
    {
        await _context.AddAsync(video);
        return video;
    }

    public async Task<IEnumerable<Video>> GetAllAsync() =>
         await _context.Videos.AsNoTracking().ToArrayAsync();

    public async Task<IEnumerable<Video>> GetAllAsync(Expression<Func<Video, bool>> quando = null)
    {
        if (quando == null)
        {
            return await _context.Videos.AsNoTracking().ToListAsync();
        }
        return await _context.Videos.AsNoTracking().Where(quando).ToListAsync();
    }

    public async Task<Video> GetByIdAsync(int id) =>
        await _context.Videos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public void Remove(Video video)
    {
        _context.Videos.Remove(video);
    }

    public void Update(Video video)
    {
        _context.Videos.Update(video);
    }
}
