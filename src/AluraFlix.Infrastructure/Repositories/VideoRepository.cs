using AluraFlix.Domain.Entities;
using AluraFlix.Domain.Interfaces;
using AluraFlix.Infrastructure.Context;

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
         _context.Videos.AsEnumerable();
}
