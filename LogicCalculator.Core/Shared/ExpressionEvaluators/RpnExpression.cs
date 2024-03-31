using LogicCalculator.Core.Shared.Interfaces;

namespace LogicCalculator.Core.Shared.ExpressionEvaluators;

public class RpnExpression : IExpression
{
    private IEnumerable<IToken> _tokens;

    private Dictionary<IToken, Func<double[], double>>? _func;
    // 3 2 +
    public RpnExpression(IEnumerable<IToken> tokens, Dictionary<IToken, Func<double[], double>> func)
    {
        _tokens = tokens;
        _func = func;
    }
    
    public RpnExpression(IEnumerable<IToken> tokens)
    {
        _tokens = tokens;
    }

    public double Evaluate((string, double)[] variables)
    {
        throw new NotImplementedException();
    }
}