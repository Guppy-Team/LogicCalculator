namespace LogicCalculator.Core.Shared.ExpressionEvaluators;

// TODO переделать под новую структуру
public class RpnConverter
{
//     public List<IToken> Convert(List<IToken> tokens)
//     {
//         var output = new List<IToken>();
//         var operatorStack = new Stack<IToken>();
//
//         foreach (var token in tokens)
//         {
//             switch (token.Type)
//             {
//                 case TokenType.Number:
//                 case TokenType.Variable:
//                     output.Add(token);
//                     break;
//
//                 case TokenType.Function:
//                     operatorStack.Push(token);
//                     break;
//
//                 case TokenType.Operator:
//                 case TokenType.LogicalOperator:
//                     while (operatorStack.Count > 0 &&
//                            (operatorStack.Peek().Type == TokenType.Operator ||
//                             operatorStack.Peek().Type == TokenType.Function ||
//                             operatorStack.Peek().Type == TokenType.LogicalOperator) &&
//                            GetPriority(token) <= GetPriority(operatorStack.Peek()))
//                     {
//                         output.Add(operatorStack.Pop());
//                     }
//
//                     operatorStack.Push(token);
//                     break;
//
//                 case TokenType.LeftBracket:
//                     operatorStack.Push(token);
//                     break;
//
//                 case TokenType.RightBracket:
//                     while (operatorStack.Count > 0 && operatorStack.Peek().Type != TokenType.LeftBracket)
//                     {
//                         output.Add(operatorStack.Pop());
//                     }
//
//                     if (operatorStack.Count > 0 && operatorStack.Peek().Type == TokenType.LeftBracket)
//                     {
//                         operatorStack.Pop();
//                     }
//
//                     if (operatorStack.Count > 0 && operatorStack.Peek().Type == TokenType.Function)
//                     {
//                         output.Add(operatorStack.Pop());
//                     }
//
//                     break;
//             }
//         }
//
//         while (operatorStack.Count > 0)
//         {
//             if (operatorStack.Peek().Type == TokenType.LeftBracket)
//             {
//                 throw new ArgumentException("Mismatched parentheses.");
//             }
//
//             output.Add(operatorStack.Pop());
//         }
//
//         return output;
//     }
//
//     private int GetPriority(IToken token)
//     {
//         return token switch
//         {
//             OperatorToken operatorToken => operatorToken.Priority,
//             LogicalOperatorToken logicalOperatorToken => logicalOperatorToken.Priority,
//             _ => 0
//         };
//     }
}