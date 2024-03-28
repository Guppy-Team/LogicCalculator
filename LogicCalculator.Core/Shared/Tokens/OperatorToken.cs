using LogicCalculator.Core.Shared.Interfaces;

namespace LogicCalculator.Core.Shared.Tokens;

public class OperatorToken : IToken
{
    public readonly TokenType Type = TokenType.Operator;
    public string Value { get; set; }

    public OperatorToken(string value)
    {
        Value = value;
    }
}