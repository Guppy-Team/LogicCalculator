namespace LogicCalculator.Core.Shared.Interfaces;

public interface IExpression
{
    public double Evaluate((string, double)[] variables);
}