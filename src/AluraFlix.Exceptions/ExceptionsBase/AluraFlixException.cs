namespace AluraFlix.Exceptions.ExceptionsBase;


public class AluraFlixException : SystemException
{
    public AluraFlixException(string mensagem) : base(mensagem)
    {
    }
}