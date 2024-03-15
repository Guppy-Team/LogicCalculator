using LogicCalculator.Core.Shared.Interfaces;

namespace LogicCalculator.Core.Shared.Tokens;

public class NumberToken : IToken
{
    public TokenType Type => TokenType.Number;
    public string Value { get; }
    public double NumericValue { get; }
    public int Priority => 0;

    public NumberToken(string value)
    {
        Value = value;
        NumericValue = double.Parse(value);
    }
}