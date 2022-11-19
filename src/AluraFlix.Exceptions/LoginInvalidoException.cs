using AluraFlix.Exceptions.ExceptionsBase;

namespace AluraFlix.Exceptions;
public class LoginInvalidoException : AluraFlixException
{
    public LoginInvalidoException() : base(ResourceMensagensDeErro.LOGIN_INVALIDO)
    {
    }
}
