using AluraFlix.Application.UseCases.Commands;
using AluraFlix.Application.UseCases.Results;

namespace AluraFlix.Application.UseCases.Handlers;
public interface IHandler<T>
where T : ICommand
{
    Task<RequestResult> Handle(T command);
}
