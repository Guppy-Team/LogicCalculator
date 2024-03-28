using LogicCalculator.Core.Shared.Interfaces;

namespace LogicCalculator.Core.Shared.Tokens;

public class NumberToken : IToken
{
    public readonly TokenType Type = TokenType.Number;
    public double Value { get; }
    
    public NumberToken(string value)
    {
        if (!double.TryParse(value, out double numValue))
        {
            throw new ArgumentException("Value must be a valid numeric string.");
        }

        Value = numValue;
    }
}