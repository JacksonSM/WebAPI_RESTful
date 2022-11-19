using AluraFlix.Application.Tools;
using AluraFlix.Application.UseCases.Commands.Usuario;
using AluraFlix.Application.UseCases.Results;
using AluraFlix.Domain.Interfaces;
using AluraFlix.Exceptions;

namespace AluraFlix.Application.UseCases.Handlers.Usuario;
public class UsuarioLoginHandler : IHandler<UsuarioLoginCommand>
{
    private readonly IUsuarioRepository _usuarioRepo;
    private readonly TokenController _tokenController;
    private readonly PasswordEncryptor _passwordEncryptor;

    public UsuarioLoginHandler(
        IUsuarioRepository usuarioRepo,
        TokenController tokenController, 
        PasswordEncryptor passwordEncryptor)
    {
        _usuarioRepo = usuarioRepo;
        _tokenController = tokenController;
        _passwordEncryptor = passwordEncryptor;
    }

    public async Task<RequestResult> Handle(UsuarioLoginCommand command)
    {
        var senhaCriptografada = _passwordEncryptor.Encrypt(command.Senha);

        var usuario = await _usuarioRepo.GetByEmailPasswordAsync(command.Email, senhaCriptografada);

        if (usuario == null)
            throw new LoginInvalidoException();

        var token = _tokenController.Generate(usuario.Email);
        var response = new LoginResult
        {
            Nome = usuario.Nome,
            Token = token
        };

        return new RequestResult().Ok(response);
    }
}
