using LogicCalculator.Core.Shared.Interfaces;

namespace LogicCalculator.Core.Shared.Tokens;

public class FunctionToken : IToken
{
    public TokenType Type => TokenType.Function;
    public string Value { get; }

    public int Priority => 5;

    public FunctionToken(string value)
    {
        Value = value;
    }
}