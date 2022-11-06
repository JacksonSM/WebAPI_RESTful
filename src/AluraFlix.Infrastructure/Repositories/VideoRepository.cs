using AluraFlix.Domain.Entities;
using AluraFlix.Domain.Interfaces;
using AluraFlix.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

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
         await _context.Videos.ToArrayAsync();

    public async Task<Video> GetByIdAsync(int id) =>
        await _context.Videos.FirstOrDefaultAsync(x => x.Id == id);

    public void Remove(Video video)
    {
        _context.Videos.Remove(video);
    }

    public void Update(Video video)
    {
        _context.Videos.Update(video);
    }
}
