using AluraFlix.Application.Tools;
using AluraFlix.Application.UseCases.Commands.Usuario;
using AluraFlix.Application.UseCases.Results;
using AluraFlix.Domain.Interfaces;
using AluraFlix.Exceptions;
using AluraFlix.Exceptions.ExceptionsBase;

namespace AluraFlix.Application.UseCases.Handlers.Usuario.Registrar;
public class RegistrarUsuarioHandler : IHandler<RegistrarUsuarioCommand>
{
    private readonly IUsuarioRepository _usuarioRepo;
    private readonly IUnitOfWork _uow;
    private readonly PasswordEncryptor _passwordEncryptor;
    private readonly TokenController _tokenController;

    public RegistrarUsuarioHandler(
        IUsuarioRepository usuarioRepo,
        IUnitOfWork uow,
        PasswordEncryptor passwordEncryptor,
        TokenController tokenController)
    {
        _usuarioRepo = usuarioRepo;
        _uow = uow;
        _passwordEncryptor = passwordEncryptor;
        _tokenController = tokenController;
    }

    public async Task<RequestResult> Handle(RegistrarUsuarioCommand command)
    {
        await ValidarAsync(command);

        var senhaCriptografada = _passwordEncryptor.Encrypt(command.Senha);

        var usuarioEntity = new Domain.Entities.Usuario
            (
                nome: command.Nome,
                email: command.Email,
                senha: senhaCriptografada
            );

        await _usuarioRepo.AddAsync(usuarioEntity);
        await _uow.CommitAsync();

        var token = _tokenController.Generate(usuarioEntity.Email);

        var response = new RegistrarUsuarioResult
        {
            Nome = usuarioEntity.Nome,
            Email = usuarioEntity.Email,
            Token = token
        };

        return new RequestResult().Created(response);
    }

    private async Task ValidarAsync(RegistrarUsuarioCommand command)
    {
        var validator = new RegistrarUsuarioValidator();
        var validationResult = validator.Validate(command);

        var existeEmail = await _usuarioRepo.ExistEmailAsync(command.Email);

        if (existeEmail)
            validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure
                ("Email", ResourceMensagensDeErro.EMAIL_EXISTENTE));

        if (!validationResult.IsValid)
        {
            var mensagesDeErro = validationResult.Errors.Select(c => c.ErrorMessage).ToList();
            throw new ErrosDeValidacaoException(mensagesDeErro);
        }
    }
}
