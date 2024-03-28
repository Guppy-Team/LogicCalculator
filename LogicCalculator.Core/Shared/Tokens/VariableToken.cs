using LogicCalculator.Core.Shared.Interfaces;

namespace LogicCalculator.Core.Shared.Tokens;

public class VariableToken : IToken
{
    public readonly TokenType Type = TokenType.Variable;
    public string Value { get; }
    
    public VariableToken(string value)
    {
        Value = value;
    }
}