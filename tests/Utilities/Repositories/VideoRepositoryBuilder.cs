using AluraFlix.Domain.Entities;
using AluraFlix.Domain.Interfaces;
using Moq;
using System.Linq.Expressions;

namespace Utilities.Repositories;
public class VideoRepositoryBuilder
{
    private static VideoRepositoryBuilder _instance;
    private readonly Mock<IVideosRepository> _repository;

    private VideoRepositoryBuilder()
    {
        if (_repository is null)
        {
            _repository = new Mock<IVideosRepository>();
        }
    }

    public static VideoRepositoryBuilder Instance()
    {
        _instance = new VideoRepositoryBuilder();
        return _instance;
    }
    public VideoRepositoryBuilder GetById(Video video)
    {
        _repository.Setup(i => i.GetByIdAsync(video.Id)).ReturnsAsync(video);

        return this;
    }
    public VideoRepositoryBuilder GetAll(string query, Video? video, int? paginaAtual, int? videosPorPagina)
    {

        if (string.IsNullOrEmpty(query))
        {
            if (video is not null)
            {
                _repository.Setup(i => i
                    .GetAllWithPaginationAsync(paginaAtual, videosPorPagina))
                    .ReturnsAsync((new Video[] { video }, 1));
            }
            else
            {
                _repository.Setup(i => i
                    .GetAllWithPaginationAsync(paginaAtual, videosPorPagina))
                    .ReturnsAsync((Array.Empty<Video>(), 1));
            }
        }

        if (video is not null)
        {
            _repository.Setup(i => i
                .GetAllWithPaginationAsync(paginaAtual, videosPorPagina, It.IsAny<Expression<Func<Video, bool>>>()))
                .ReturnsAsync((new Video[] { video }, 1));
        }
        else
        {
            _repository.Setup(i => i
                .GetAllWithPaginationAsync(paginaAtual, videosPorPagina, It.IsAny<Expression<Func<Video, bool>>>()))
                .ReturnsAsync((Array.Empty<Video>(), 1));
        }


        return this;
    }
    public IVideosRepository Build()
    {
        return _repository.Object;
    }
}
