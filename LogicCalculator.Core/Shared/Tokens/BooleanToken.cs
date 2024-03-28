using LogicCalculator.Core.Shared.Interfaces;

namespace LogicCalculator.Core.Shared.Tokens;

public class BooleanToken : IToken
{
    public readonly TokenType Type = TokenType.Boolean;
    public bool BooleanValue { get; }

    public BooleanToken(bool value)
    {
        BooleanValue = value;
    }
}