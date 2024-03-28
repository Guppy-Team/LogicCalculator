using LogicCalculator.Core.Shared.Interfaces;
using LogicCalculator.Core.Shared.Tokens;

namespace LogicCalculator.Core.LogicalExpression;

public class LogicalExpressionEvaluator : ILogicalExpressionEvaluator
{
    public bool Evaluate(List<IToken> tokens, Dictionary<string, bool> variables)
    {
        var outputQueue = new Queue<IToken>();
        var operatorStack = new Stack<IToken>();

        foreach (var token in tokens)
        {
            switch (token)
            {
                case VariableToken variableToken:
                    if (variables.TryGetValue(variableToken.Value, out var value))
                    {
                        outputQueue.Enqueue(new BooleanToken(value));
                    }
                    else
                    {
                        outputQueue.Enqueue(new BooleanToken(false));
                    }

                    break;
                case BracketToken bracketToken:
                    if (bracketToken.Value == "(")
                    {
                        operatorStack.Push(bracketToken);
                    }
                    else
                    {
                        while (operatorStack.Count > 0 && operatorStack.Peek() is not BracketToken)
                        {
                            outputQueue.Enqueue(operatorStack.Pop());
                        }

                        if (operatorStack.Count > 0 && operatorStack.Peek() is BracketToken)
                        {
                            operatorStack.Pop();
                        }
                    }

                    break;
                // TODO переделать под новую структуру
                // case LogicalOperatorToken operatorToken:
                //     while (operatorStack.Count > 0 && operatorStack.Peek() is LogicalOperatorToken stackOperator &&
                //            operatorToken.Priority <= stackOperator.Priority)
                //     {
                //         outputQueue.Enqueue(operatorStack.Pop());
                //     }
                //
                //     operatorStack.Push(operatorToken);
                //     break;
            }
        }

        while (operatorStack.Count > 0)
        {
            outputQueue.Enqueue(operatorStack.Pop());
        }

        var stack = new Stack<bool>();
        foreach (var token in outputQueue)
        {
            switch (token)
            {
                case BooleanToken booleanToken:
                    stack.Push(booleanToken.BooleanValue);
                    break;
                case LogicalOperatorToken operatorToken:
                    EvaluateOperator(stack, operatorToken);
                    break;
            }
        }

        return stack.Count == 1 && stack.Pop();
    }

    private void EvaluateOperator(Stack<bool> stack, LogicalOperatorToken operatorToken)
    {
        switch (operatorToken.Value)
        {
            case "!":
                if (stack.Count >= 1)
                {
                    var operand = stack.Pop();
                    stack.Push(!operand);
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
                            stack.Push(left && right);
                            break;
                        case "||":
                            stack.Push(left || right);
                            break;
                        case "=>":
                            stack.Push(!left || right);
                            break;
                        case "<=>":
                            stack.Push(left == right);
                            break;
                    }
                }

                break;
        }
    }
}