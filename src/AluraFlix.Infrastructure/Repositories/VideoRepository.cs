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

    public async Task<(IEnumerable<Video>, int qtdVideos)> GetAllWithPaginationAsync(
        int? paginaAtual, int? videosPorPagina, Expression<Func<Video, bool>>? filtro = null)
    {
        var query = _context.Videos.AsQueryable();

        if (filtro is not null)
            query = query.AsNoTracking().Where(filtro);

        query = SetPagination(paginaAtual, videosPorPagina, query);

        var videos = await query.ToArrayAsync();

        var qtdVideos = filtro is null ? await _context.Videos.AsNoTracking().CountAsync() :
                                         await _context.Videos.AsNoTracking().Where(filtro).CountAsync();

        return (videos, qtdVideos);
    }

    public async Task<(IEnumerable<Video>, int qtdVideos)> GetAllWithPaginationAsync(int? paginaAtual, int? videosPorPagina)
    {
        var query = _context.Videos.AsQueryable();

        query = SetPagination(paginaAtual, videosPorPagina, query);

        var videos = await query.ToArrayAsync();
        var qtdVideos = await _context.Videos.AsNoTracking().CountAsync();

        return (videos, qtdVideos);
    }
    public async Task<(IEnumerable<Video>, int qtdVideos)> GetAllWithPaginationAsync(
        int take, int? paginaAtual = null, int? videosPorPagina = null)
    {
        var query = _context.Videos.AsQueryable();

        query = query.AsNoTracking().OrderBy(x => x.Id).Take(take);

        var qtdVideos = await query.AsNoTracking().CountAsync();

        query = SetPagination(paginaAtual, videosPorPagina, query);

        var videos = await query.ToArrayAsync();

        return (videos, qtdVideos);
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

    private IQueryable<Video> SetPagination(int? paginaAtual, int? videosPorPagina, IQueryable<Video> query)
    {
        if (paginaAtual.HasValue && videosPorPagina.HasValue)
              return query.AsNoTracking()
                     .Skip((paginaAtual.Value - 1) * videosPorPagina.Value)
                     .Take(videosPorPagina.Value);
        return query;
    }
}
