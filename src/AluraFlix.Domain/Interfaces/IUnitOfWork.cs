namespace AluraFlix.Domain.Interfaces;
public interface IUnitOfWork
{
    Task CommitAsync();
}
