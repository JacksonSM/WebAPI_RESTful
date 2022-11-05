using AluraFlix.Domain.Entities;

namespace AluraFlix.Domain.Interfaces;
public interface IVideosRepository
{
    Task<Video> AddAsync(Video video);
    Task<IEnumerable<Video>> GetAllAsync();
    Task<Video> GetByIdAsync(int id);
    void Update(Video video);
}
