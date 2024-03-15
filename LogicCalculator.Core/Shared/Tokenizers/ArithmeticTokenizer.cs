using System.Text.RegularExpressions;
using LogicCalculator.Core.Shared.Interfaces;
using LogicCalculator.Core.Shared.Tokens;

namespace LogicCalculator.Core.Shared.Tokenizers;

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
                else
                {
                    // Игнорировать некорректное размещение десятичной точки
                    continue;
                }
            }
            else
            {
                if (currentToken.Length > 0)
                {
                    if (double.TryParse(currentToken, out _))
                    {
                        tokens.Add(new NumberToken(currentToken));
                    }
                    else if (_functions.Contains(currentToken))
                    {
                        tokens.Add(new FunctionToken(currentToken));
                    }
                    else
                    {
                        tokens.Add(new VariableToken(currentToken));
                    }

                    currentToken = string.Empty;
                }

                if (currentChar == '(')
                {
                    tokens.Add(new BracketToken("("));
                }
                else if (currentChar == ')')
                {
                    tokens.Add(new BracketToken(")"));
                }
                else if (_operators.Contains(currentChar.ToString()))
                {
                    tokens.Add(new OperatorToken(currentChar.ToString()));
                }
            }
        }

        if (currentToken.Length > 0)
        {
            if (double.TryParse(currentToken, out _))
            {
                tokens.Add(new NumberToken(currentToken));
            }
            else if (_functions.Contains(currentToken))
            {
                tokens.Add(new FunctionToken(currentToken));
            }
            else
            {
                tokens.Add(new VariableToken(currentToken));
            }
        }

        return tokens;
    }
}