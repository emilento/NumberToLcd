using System.Text;

namespace NumberToLcd;

internal class LcdDisplay
{
    private readonly string _text;
        
    private readonly int _digitWidth;

    private readonly int _digitHeight;

    private static readonly IReadOnlyDictionary<char, string[]> Digits = new Dictionary<char, string[]>()
    {
        { '0', new[] { " _ ", "| |", "|_|" } },
        { '1', new[] { "   ", "  |", "  |" } },
        { '2', new[] { " _ ", " _|", "|_ " } },
        { '3', new[] { " _ ", " _|", " _|" } },
        { '4', new[] { "   ", "|_|", "  |" } },
        { '5', new[] { " _ ", "|_ ", " _|" } },
        { '6', new[] { " _ ", "|_ ", "|_|" } },
        { '7', new[] { " _ ", "  |", "  |" } },
        { '8', new[] { " _ ", "|_|", "|_|" } },
        { '9', new[] { " _ ", "|_|", " _|" } }
    };

    public LcdDisplay(string? text, int digitWidth, int digitHeight)
    {
        if (string.IsNullOrWhiteSpace(text) || !text.All(char.IsDigit))
        {
            throw new ArgumentException("Wrong input!!!", nameof(text));
        }
            
        if (digitWidth < 1)
        {
            throw new ArgumentException("Wrong input!!!", nameof(digitWidth));
        }

        if (digitHeight <= 0 || digitHeight % 2 != 0)
        {
            throw new ArgumentException("Wrong input!!!", nameof(digitHeight));
        }

        _text = text;
        _digitWidth = digitWidth;
        _digitHeight = digitHeight;
    }

    public override string ToString()
    {
        var result = new StringBuilder();

        foreach (var digit in _text)
        {
            result.Append(Digits[digit][0].Replace("_", "_".PadRight(_digitWidth, '_')));
        }

        result.AppendLine();

        for (var i = 1; i <= 2; i++)
        {
            for (var j = 1; j <= Math.Ceiling(_digitHeight / 2.0f); j++)
            {
                foreach (var digit in _text)
                {
                    result.Append(j == (int)Math.Ceiling(_digitHeight / 2.0f)
                        ? Digits[digit][i].Replace("_", "_".PadRight(_digitWidth, '_'))
                        : Digits[digit][i].Replace("_", " ".PadRight(_digitWidth, ' ')));
                }

                result.AppendLine();
            }
        }

        return result.ToString();
    }
}