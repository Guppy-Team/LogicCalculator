using LogicCalculator.Core.Shared.Interfaces;
using LogicCalculator.Core.Shared.Tokens;

namespace LogicCalculator.Core.Shared.ExpressionEvaluators;

public class RpnExpressionBuilder
{
    //! Нужно принимать через правила
    private static Dictionary<IToken, int> OperatorPriorities { get; set; } = new Dictionary<IToken, int>
    {
        { new PlusToken(), 2 },
        { new MinusToken(), 2 },
        { new MultiplyToken(), 3 },
        { new DivideToken(), 3 },
    };

    
    public static IExpression Build(IEnumerable<IToken> expression, Dictionary<IToken, int> operatorPriorities)
    {
        OperatorPriorities = operatorPriorities;
        
        var output = new List<IToken>();
        
        List<IToken> variables = new();
        
        var operatorStack = new Stack<IToken>();
        
        foreach (var token in expression)
        {
            switch (token)
            {
                case NumberToken:
                    variables.Add(token);
                    output.Add(token);
                    break;
                
                case VariableToken:
                    
                    output.Add(token);
                    break;
                
                case IOperator:
                    while (operatorStack.Count > 0 &&
                           (operatorStack.Peek() is IOperator) &&
                           GetPriority(token) <= GetPriority(operatorStack.Peek()))
                    {
                        output.Add(operatorStack.Pop());
                    }

                    operatorStack.Push(token);
                    break;

                case LeftBracketToken:
                    operatorStack.Push(token);
                    break;

                case RightBracketToken:
                    while (operatorStack.Count > 0 && operatorStack.Peek() is not LeftBracketToken)
                    {
                        output.Add(operatorStack.Pop());
                    }

                    if (operatorStack.Count > 0 && operatorStack.Peek() is LeftBracketToken)
                    {
                        operatorStack.Pop();
                    }

                    break;
            }
        }
        while (operatorStack.Count > 0)
        {
            if (operatorStack.Peek() is LeftBracketToken)
            {
                throw new ArgumentException("Mismatched parentheses.");
            }

            output.Add(operatorStack.Pop());
        }

        var result = new RpnExpression(output, variables);
        
        return result;
    }

    private static int GetPriority(IToken token)
    {
        return OperatorPriorities[token];
    }
}