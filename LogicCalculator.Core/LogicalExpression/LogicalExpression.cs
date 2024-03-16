using LogicCalculator.Core.Shared.Interfaces;
using LogicCalculator.Core.Shared.Tokenizers;

namespace LogicCalculator.Core.LogicalExpression;

public class LogicalExpression
{
    private readonly List<IToken> _tokens;

    public LogicalExpression(string expression)
    {
        var tokenizer = new LogicalTokenizer();
        _tokens = tokenizer.Tokenize(expression);
    }

    public bool Evaluate(Dictionary<string, bool> variables)
    {
        var evaluator = new LogicalExpressionEvaluator();
        return evaluator.Evaluate(_tokens, variables);
    }
}