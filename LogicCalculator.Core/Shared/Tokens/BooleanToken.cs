using LogicCalculator.Core.Shared.Interfaces;

namespace LogicCalculator.Core.Shared.Tokens;

public class BooleanToken : IToken
{
    public TokenType Type => TokenType.Boolean;
    public string Value { get; }
    public int Priority => 0;
    public bool BooleanValue { get; }

    public BooleanToken(bool value)
    {
        BooleanValue = value;
    }

    public double Evaluate(double[] args)
    {
        return 0;
    }
}