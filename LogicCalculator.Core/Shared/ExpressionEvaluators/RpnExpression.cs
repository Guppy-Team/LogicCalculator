using LogicCalculator.Core.Shared.Interfaces;

namespace LogicCalculator.Core.Shared.ExpressionEvaluators;

public class RpnExpression : IExpression
{
    private IEnumerable<IToken> _tokens;
    private ICollection<IToken> _variables;
    // 3 2 +
    public RpnExpression(IEnumerable<IToken> tokens, ICollection<IToken> variables)
    {
        _tokens = tokens;
        _variables = variables;
    }
    
    public double Evaluate((string, double)[] variables)
    {
        throw new NotImplementedException();
    }
}