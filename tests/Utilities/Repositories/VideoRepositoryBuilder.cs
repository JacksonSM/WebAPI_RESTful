using AluraFlix.Domain.Interfaces;
using Moq;

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

    public IVideosRepository Build()
    {
        return _repository.Object;
    }
}
