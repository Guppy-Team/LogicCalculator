using LogicCalculator.Core.Shared.Interfaces;
using LogicCalculator.Core.Shared.Tokens;

namespace LogicCalculator.Core.LogicalExpression;

public class LogicalExpressionEvaluator : IExpressionEvaluator
{
    public T Evaluate<T>(List<IToken> tokens, Dictionary<string, T> variables) where T : struct
    {
        var stack = new Stack<T>();
        var operatorStack = new Stack<LogicalOperatorToken>();

        foreach (var token in tokens)
        {
            switch (token)
            {
                case VariableToken variableToken:
                    if (variables.TryGetValue(variableToken.Value, out var value))
                    {
                        stack.Push(value);
                    }

                    break;
                case BracketToken bracketToken:
                    switch (bracketToken.Value)
                    {
                        case "(":
                            operatorStack.Push(new LogicalOperatorToken("("));
                            break;
                        case ")":
                        {
                            while (operatorStack.Count > 0 && operatorStack.Peek().Value != "(")
                            {
                                EvaluateOperator(stack, operatorStack.Pop());
                            }

                            if (operatorStack.Count > 0 && operatorStack.Peek().Value == "(")
                            {
                                operatorStack.Pop();
                            }

                            break;
                        }
                    }

                    break;
                case LogicalOperatorToken operatorToken:
                    while (operatorStack.Count > 0 && operatorToken.Priority <= operatorStack.Peek().Priority)
                    {
                        EvaluateOperator(stack, operatorStack.Pop());
                    }

                    operatorStack.Push(operatorToken);
                    break;
            }
        }

        while (operatorStack.Count > 0)
        {
            EvaluateOperator(stack, operatorStack.Pop());
        }

        return stack.Count == 1 ? stack.Pop() : default;
    }

    private void EvaluateOperator<T>(Stack<T> stack, LogicalOperatorToken operatorToken) where T : struct
    {
        switch (operatorToken.Value)
        {
            case "!":
                if (stack.Count >= 1)
                {
                    var operand = stack.Pop();
                    stack.Push((T)(object)!(bool)(object)operand);
                }

                break;
            default:
                if (stack.Count >= 2)
                {
                    var right = stack.Pop();
                    var left = stack.Pop();
                    switch (operatorToken.Value)
                    {
                        case "&&":
                            stack.Push((T)(object)((bool)(object)left && (bool)(object)right));
                            break;
                        case "||":
                            stack.Push((T)(object)((bool)(object)left || (bool)(object)right));
                            break;
                        case "=>":
                            stack.Push((T)(object)(!(bool)(object)left || (bool)(object)right));
                            break;
                        case "<=>":
                            stack.Push((T)(object)((bool)(object)left == (bool)(object)right));
                            break;
                    }
                }

                break;
        }
    }
}