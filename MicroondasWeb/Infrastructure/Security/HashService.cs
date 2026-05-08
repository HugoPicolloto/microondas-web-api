using System.Security.Cryptography;
using System.Text;

public static class HashService
{
    public static string Gerar(string texto)
    {
        using var sha = SHA256.Create();

        var bytes = sha.ComputeHash(
            Encoding.UTF8.GetBytes(texto));

        return Convert.ToHexString(bytes);
    }
}