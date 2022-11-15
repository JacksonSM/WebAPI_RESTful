using AluraFlix.Domain.Interfaces;
using Moq;

namespace Utilities.Repositories;
public class CategoriaRepositoryBuilder
{
    private static CategoriaRepositoryBuilder _instance;
    private readonly Mock<ICategoriaRepository> _repository;

    private CategoriaRepositoryBuilder()
    {
        if (_repository is null)
        {
            _repository = new Mock<ICategoriaRepository>();
        }
    }
    public CategoriaRepositoryBuilder ExistById(int id)
    {
        if(id != 0)
            _repository.Setup(i => i.ExistById(id)).ReturnsAsync(true);

        return this;
    }

    public static CategoriaRepositoryBuilder Instance()
    {
        _instance = new CategoriaRepositoryBuilder();
        return _instance;
    }

    public ICategoriaRepository Build()
    {
        return _repository.Object;
    }
}
