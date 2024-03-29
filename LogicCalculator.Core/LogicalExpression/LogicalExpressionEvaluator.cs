using LogicCalculator.Core.Shared.Interfaces;

namespace LogicCalculator.Core.LogicalExpression;

public class LogicalExpressionEvaluator : ILogicalExpressionEvaluator
{
    public bool Evaluate(List<IToken> tokens, Dictionary<string, bool> variables)
    {
        throw new NotImplementedException();
    }

    // private void EvaluateOperator(Stack<bool> stack, LogicalOperatorToken operatorToken)
    // {
    //     switch (operatorToken.Value)
    //     {
    //         case "!":
    //             if (stack.Count >= 1)
    //             {
    //                 var operand = stack.Pop();
    //                 stack.Push(!operand);
    //             }
    //
    //             break;
    //         default:
    //             if (stack.Count >= 2)
    //             {
    //                 var right = stack.Pop();
    //                 var left = stack.Pop();
    //                 switch (operatorToken.Value)
    //                 {
    //                     case "&&":
    //                         stack.Push(left && right);
    //                         break;
    //                     case "||":
    //                         stack.Push(left || right);
    //                         break;
    //                     case "=>":
    //                         stack.Push(!left || right);
    //                         break;
    //                     case "<=>":
    //                         stack.Push(left == right);
    //                         break;
    //                 }
    //             }
    //
    //             break;
    //     }
    // }
}