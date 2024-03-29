using LogicCalculator.Core.Shared.Interfaces;

namespace LogicCalculator.Core.Shared.Tokenizers;

// TODO Переделать под новую структуру 
public class ArithmeticTokenizer : ITokenizer
{
    private readonly string[] _operators = { "+", "-", "*", "/", "^" };
    private readonly string[] _functions = { "sin", "cos", "tg", "ctg" };

    public List<IToken> Tokenize(string expression)
    {
        var tokens = new List<IToken>();
        var currentToken = string.Empty;

        foreach (var currentChar in expression)
        {
            if (char.IsLetterOrDigit(currentChar) || currentChar == '_')
            {
                currentToken += currentChar;
            }
            else if (currentChar == '.')
            {
                if (currentToken.Length > 0 && double.TryParse(currentToken + ".", out _))
                {
                    currentToken += currentChar;
                }
            }
        }

        return tokens;
    }
}