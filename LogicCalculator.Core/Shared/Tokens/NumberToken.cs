using LogicCalculator.Core.Shared.Interfaces;

namespace LogicCalculator.Core.Shared.Tokens;

public class NumberToken : IToken
{
    public double Value { get; }
    
    public NumberToken(double value)
    {
        Value = value;
    }
}