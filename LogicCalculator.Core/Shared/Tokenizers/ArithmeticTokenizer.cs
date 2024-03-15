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
        var currentNumber = string.Empty;
        var currentVariable = string.Empty;

        foreach (var currentChar in expression)
        {
            if (char.IsLetterOrDigit(currentChar) || currentChar == '_')
            {
                if (currentNumber.Length > 0)
                {
                    tokens.Add(new NumberToken(currentNumber));
                    currentNumber = string.Empty;
                }

                currentVariable += currentChar;
            }
            else if (currentChar == '.' && currentVariable.Length == 0)
            {
                currentNumber += currentChar;
            }
            else
            {
                if (currentVariable.Length > 0)
                {
                    if (_functions.Contains(currentVariable))
                    {
                        tokens.Add(new FunctionToken(currentVariable));
                    }
                    else
                    {
                        tokens.Add(new VariableToken(currentVariable));
                    }

                    currentVariable = string.Empty;
                }

                if (currentNumber.Length > 0)
                {
                    tokens.Add(new NumberToken(currentNumber));
                    currentNumber = string.Empty;
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

        if (currentVariable.Length > 0)
        {
            if (_functions.Contains(currentVariable))
            {
                tokens.Add(new FunctionToken(currentVariable));
            }
            else
            {
                tokens.Add(new VariableToken(currentVariable));
            }
        }

        if (currentNumber.Length > 0)
        {
            tokens.Add(new NumberToken(currentNumber));
        }

        return tokens;
    }
}