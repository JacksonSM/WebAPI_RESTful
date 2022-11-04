using AluraFlix.Domain.Entities;

namespace AluraFlix.Domain.Interfaces;
public interface IVideosRepository
{
    Task<Video> AddAsync(Video video);
}
