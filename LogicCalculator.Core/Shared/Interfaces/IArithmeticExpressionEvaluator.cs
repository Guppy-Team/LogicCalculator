namespace LogicCalculator.Core.Shared.Interfaces;

public interface IArithmeticExpressionEvaluator
{
    double Evaluate(List<IToken> tokens);
    double Evaluate(List<IToken> tokens, Dictionary<string, double> variables);
}