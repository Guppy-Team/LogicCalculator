using LogicCalculator.Core.Shared.Interfaces;

namespace LogicCalculator.Core.Shared.Tokens;

public class OperatorToken : IToken
{
    public TokenType Type => TokenType.Operator;
    public string Value { get; }

    public int Priority => Value switch
    {
        "^" => 4,
        "*" or "/" => 3,
        "+" or "-" => 2,
        _ => 0
    };

    public OperatorToken(string value)
    {
        Value = value;
    }
}