using LogicCalculator.Core.Shared.Interfaces;

namespace LogicCalculator.Core.Shared.Tokens;

public class FunctionToken : IToken
{
    public readonly TokenType Type = TokenType.Function;
    public string Value { get; }

    public FunctionToken(string value)
    {
        Value = value;
    }
}