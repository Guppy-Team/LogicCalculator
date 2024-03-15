using LogicCalculator.Core.Shared.Interfaces;

namespace LogicCalculator.Core.Shared.Tokens;

public class LogicalOperatorToken : IToken
{
    public TokenType Type => TokenType.LogicalOperator;
    public string Value { get; }

    public int Priority => Value switch
    {
        "&&" => 3,
        "||" => 2,
        "=>" => 1,
        "<=>" => 1,
        _ => 0
    };

    public LogicalOperatorToken(string value)
    {
        Value = value;
    }
}