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
}