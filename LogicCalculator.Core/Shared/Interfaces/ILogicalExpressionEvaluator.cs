namespace LogicCalculator.Core.Shared.Interfaces;

public interface ILogicalExpressionEvaluator
{
    bool Evaluate(List<IToken> tokens, Dictionary<string, bool> variables);
}