using System.Security.Cryptography;

namespace DesafioBackEnd.Domain.Entities.Extensions;

public static class StringExtension
{
    public static string GetNumbers(this string text)
    {
        if (string.IsNullOrEmpty(text)) return string.Empty;

        text = text.Trim();
        var numbers = new String(text.Where(Char.IsDigit).ToArray());

        return numbers;
    }

    static HashAlgorithm _algoritmo = SHA256.Create();

    public static string CreateHash(this string password)
    {
        var encodedValue = System.Text.Encoding.UTF8.GetBytes(password);
        var encryptedPassword = _algoritmo.ComputeHash(encodedValue);
        return Convert.ToBase64String(encryptedPassword);
    }
}