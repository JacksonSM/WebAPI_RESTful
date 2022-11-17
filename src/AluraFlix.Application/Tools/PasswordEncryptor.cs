using System.Security.Cryptography;
using System.Text;

namespace AluraFlix.Application.Tools;

public class PasswordEncryptor
{
    private readonly string _extraKey;

    public PasswordEncryptor(string extraKey)
    {
        _extraKey = extraKey;
    }

    public string Encrypt(string password)
    {
        var senhaComChaveAdicional = $"{password}{_extraKey}";

        var bytes = Encoding.UTF8.GetBytes(senhaComChaveAdicional);
        var sha512 = SHA512.Create();
        byte[] hashBytes = sha512.ComputeHash(bytes);
        return StringBytes(hashBytes);
    }

    private static string StringBytes(byte[] bytes)
    {
        var sb = new StringBuilder();
        foreach (byte b in bytes)
        {
            var hex = b.ToString("x2");
            sb.Append(hex);
        }
        return sb.ToString();
    }
}
