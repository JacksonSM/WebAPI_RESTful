using AluraFlix.Domain.Entities;
using System.Linq.Expressions;

namespace AluraFlix.Domain.Interfaces;
public interface IVideosRepository
{
    Task<Video> AddAsync(Video video);
    Task<(IEnumerable<Video>, int qtdVideos)> GetAllWithPaginationAsync(
        int? paginaAtual = null, int? videosPorPagina = null);
    Task<(IEnumerable<Video>, int qtdVideos)> GetAllWithPaginationAsync(
        int? paginaAtual = null, int? videosPorPagina = null, Expression<Func<Video, bool>>? filtro = null);
    Task<(IEnumerable<Video>, int qtdVideos)> GetAllWithPaginationAsync(
        int take, int? paginaAtual = null, int? videosPorPagina = null);
    Task<Video> GetByIdAsync(int id);
    void Update(Video video);
    void Remove(Video video);
}
