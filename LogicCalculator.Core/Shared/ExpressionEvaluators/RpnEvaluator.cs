using LogicCalculator.Core.Shared.Interfaces;
using LogicCalculator.Core.Shared.Tokens;

namespace LogicCalculator.Core.Shared.ExpressionEvaluators;

public class RpnEvaluator : IArithmeticExpressionEvaluator
{
    public double Evaluate(List<IToken> tokens)
    {
        return Evaluate(tokens, new Dictionary<string, double>());
    }

    public double Evaluate(List<IToken> tokens, Dictionary<string, double> variables)
    {
        var stack = new Stack<double>();

        // TODO переделать под новую структуру
        foreach (var token in tokens)
        {
            // switch (token.Type)
            // {
            //     case TokenType.Number:
            //         stack.Push(((NumberToken)token).Value);
            //         break;
            //
            //     case TokenType.Variable:
            //         if (variables.TryGetValue(token.Value, out var variableValue))
            //         {
            //             stack.Push(variableValue);
            //         }
            //         else
            //         {
            //             stack.Push(0);
            //         }
            //
            //         break;
            //
            //     case TokenType.Operator:
            //         var right = stack.Pop();
            //         var left = stack.Pop();
            //         // TODO Token shouldn't have Evaluate
            //         //var result = token.Evaluate(new[] { left, right });
            //         //stack.Push(result);
            //         break;
            //
            //     case TokenType.Function:
            //         var argument = stack.Pop();
            //         // TODO Token shouldn't have Evaluate
            //         //var functionResult = token.Evaluate(new[] { argument });
            //         //stack.Push(functionResult);
            //         break;
            // }
        }

        return stack.Count == 0 ? 0 : stack.Pop();
    }
}