using LogicCalculator.Core.Shared.Interfaces;

namespace LogicCalculator.Core.Shared.Tokens;

public class Token : IToken
{
    public TokenType Type { get; }
    
    public string Value { get; set; }
    
    //TODO: этого тут не должно быть
    // int Priority { get; }
    //
    //TODO: этого тут не должно быть
    // double Evaluate(double[] args);
}