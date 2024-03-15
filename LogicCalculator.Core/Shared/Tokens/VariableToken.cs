using LogicCalculator.Core.Shared.Interfaces;

namespace LogicCalculator.Core.Shared.Tokens;

public class VariableToken : IToken
{
    public TokenType Type => TokenType.Variable;
    public string Value { get; }
    public int Priority => 0;

    public VariableToken(string value)
    {
        Value = value;
    }

    public double Evaluate(double[] args)
    {
        return 0;
    }
}