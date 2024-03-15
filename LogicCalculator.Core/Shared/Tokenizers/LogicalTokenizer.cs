using LogicCalculator.Core.Shared.Interfaces;
using LogicCalculator.Core.Shared.Tokens;

namespace LogicCalculator.Core.Shared.Tokenizers;

public class LogicalTokenizer : ITokenizer
{
    private readonly string[] _operators = { "&&", "||", "=>", "<=>", "!" };

    public List<IToken> Tokenize(string expression)
    {
        var tokens = new List<IToken>();
        var currentToken = string.Empty;

        for (int i = 0; i < expression.Length; i++)
        {
            var currentChar = expression[i];

            if (char.IsLetterOrDigit(currentChar) || currentChar == '_')
            {
                currentToken += currentChar;
            }
            else
            {
                if (currentToken.Length > 0)
                {
                    tokens.Add(new VariableToken(currentToken));
                    currentToken = string.Empty;
                }

                switch (currentChar)
                {
                    case '(':
                        tokens.Add(new BracketToken("("));
                        break;
                    case ')':
                        tokens.Add(new BracketToken(")"));
                        break;
                    case '!':
                        tokens.Add(new LogicalOperatorToken("!"));
                        break;
                    case '&' when i + 1 < expression.Length && expression[i + 1] == '&':
                        tokens.Add(new LogicalOperatorToken("&&"));
                        i++;
                        break;
                    case '|' when i + 1 < expression.Length && expression[i + 1] == '|':
                        tokens.Add(new LogicalOperatorToken("||"));
                        i++;
                        break;
                    case '=' when i + 1 < expression.Length && expression[i + 1] == '>':
                        tokens.Add(new LogicalOperatorToken("=>"));
                        i++;
                        break;
                    case '<' when i + 2 < expression.Length && expression[i + 1] == '=' &&
                                  expression[i + 2] == '>':
                        tokens.Add(new LogicalOperatorToken("<=>"));
                        i += 2;
                        break;
                }
            }
        }

        if (currentToken.Length > 0)
        {
            tokens.Add(new VariableToken(currentToken));
        }

        return tokens;
    }
}