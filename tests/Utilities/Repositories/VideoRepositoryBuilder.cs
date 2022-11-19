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
    public IVideosRepository Build()
    {
        return _repository.Object;
    }
}
