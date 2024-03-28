using LogicCalculator.Core.Shared.Interfaces;

namespace LogicCalculator.Core.Shared.Tokens;

public class LogicalOperatorToken : IToken
{
    public readonly TokenType Type = TokenType.LogicalOperator;
    public string Value { get; }

    public LogicalOperatorToken(string value)
    {
        Value = value;
    }
}