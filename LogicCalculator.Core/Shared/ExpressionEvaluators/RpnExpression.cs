using LogicCalculator.Core.Shared.Interfaces;

namespace LogicCalculator.Core.Shared.ExpressionEvaluators;

record RpnExpression(IToken[] tokens, Dictionary<IToken, Func<double[],double>> func) : IExpression
{
    // 3 2 +
    public double Evaluate((string, double)[] variables)
    {
        throw new NotImplementedException();
    }
}