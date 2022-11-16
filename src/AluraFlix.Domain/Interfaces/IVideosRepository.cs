using AluraFlix.Domain.Entities;
using System.Linq.Expressions;

namespace AluraFlix.Domain.Interfaces;
public interface IVideosRepository
{
    Task<Video> AddAsync(Video video);
    Task<IEnumerable<Video>> GetAllAsync(Expression<Func<Video, bool>>? quando = null);
    Task<Video> GetByIdAsync(int id);
    void Update(Video video);
    void Remove(Video video);
}
