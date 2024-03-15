using LogicCalculator.Core.Shared.Interfaces;
using LogicCalculator.Core.Shared.Tokens;

namespace LogicCalculator.Core.Shared.ExpressionEvaluators;

public class RpnEvaluator : IExpressionEvaluator
{
    public T Evaluate<T>(List<IToken> tokens, Dictionary<string, T> variables) where T : struct
    {
        var stack = new Stack<T>();

        foreach (var token in tokens)
        {
            switch (token.Type)
            {
                case TokenType.Number:
                    stack.Push((T)(object)((NumberToken)token).NumericValue);
                    break;

                case TokenType.Variable:
                    if (variables.TryGetValue(token.Value, out var variableValue))
                    {
                        stack.Push(variableValue);
                    }
                    else
                    {
                        stack.Push(default(T));
                    }

                    break;

                case TokenType.Operator:
                    var right = stack.Pop();
                    var left = stack.Pop();
                    var result = (T)(object)token.Evaluate(new[] { (double)(object)left, (double)(object)right });
                    stack.Push(result);
                    break;

                case TokenType.Function:
                    var argument = stack.Pop();
                    var functionResult = (T)(object)token.Evaluate(new[] { (double)(object)argument });
                    stack.Push(functionResult);
                    break;
            }
        }

        return stack.Count == 0 ? default(T) : stack.Pop();
    }
}