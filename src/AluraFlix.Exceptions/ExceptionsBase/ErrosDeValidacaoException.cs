namespace AluraFlix.Exceptions.ExceptionsBase;

public class ErrosDeValidacaoException : AluraFlixException
{
    public List<string> MensagensDeErro { get; set; }

    public ErrosDeValidacaoException(List<string> mensagensDeErro) : base(string.Empty)
    {
        MensagensDeErro = mensagensDeErro;
    }
}
