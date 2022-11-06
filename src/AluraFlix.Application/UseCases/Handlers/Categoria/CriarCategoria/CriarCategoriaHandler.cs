using AluraFlix.Application.UseCases.Commands.Categoria;
using AluraFlix.Application.UseCases.Results;
using AluraFlix.Domain.Interfaces;
using AluraFlix.Exceptions.ExceptionsBase;
using AutoMapper;

namespace AluraFlix.Application.UseCases.Handlers.Categoria.CriarCategoria;
public class CriarCategoriaHandler : IHandler<CriarCategoriaCommand>
{
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public CriarCategoriaHandler(ICategoriaRepository categoriaRepository, IUnitOfWork uow, IMapper mapper)
    {
        _categoriaRepository = categoriaRepository;
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<RequestResult> Handle(CriarCategoriaCommand command)
    {
        Validar(command);
        var categoriaEntity = _mapper.Map<Domain.Entities.Categoria>(command);

        await _categoriaRepository.AddAsync(categoriaEntity);
        await _uow.CommitAsync();

        return new RequestResult().Created(categoriaEntity);
    }

    private void Validar(CriarCategoriaCommand command)
    {
        var validator = new CriarCategoriaValidator();
        var validationResult = validator.Validate(command);


        if (!validationResult.IsValid)
        {
            var mensagesDeErro = validationResult.Errors.Select(c => c.ErrorMessage).ToList();
            throw new ErrosDeValidacaoException(mensagesDeErro);
        }
    }
}
