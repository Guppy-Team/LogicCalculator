using LogicCalculator.Core.Shared.Interfaces;

namespace LogicCalculator.Core.Shared.ExpressionEvaluators;

public class Expression : IExpression
{
    public double Evaluate((string, double)[] variables)
    {
        throw new NotImplementedException();
    }
}