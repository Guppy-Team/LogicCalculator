namespace LogicCalculator.Core.Shared.Interfaces;

public interface IExpressionEvaluator
{
    T Evaluate<T>(List<IToken> tokens, Dictionary<string, T> variables) where T : struct;
}