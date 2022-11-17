using AluraFlix.Exceptions;
using AluraFlix.Exceptions.ExceptionsBase;

namespace MeuLivroDeReceitas.Exceptions.ExceptionsBase;
public class LoginInvalidoException : AluraFlixException
{
    public LoginInvalidoException() : base(ResourceMensagensDeErro.LOGIN_INVALIDO)
    {
    }
}
