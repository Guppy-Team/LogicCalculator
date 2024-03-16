using LogicCalculator.Core.Shared.Interfaces;

namespace LogicCalculator.Core.Shared.Tokens;

public class OperatorToken : IToken
{
    public TokenType Type => TokenType.Operator;
    public string Value { get; }

    public int Priority => Value switch
    {
        "^" => 4,
        "*" or "/" => 3,
        "+" or "-" => 2,
        _ => 0
    };

    public OperatorToken(string value)
    {
        Value = value;
    }

    public double Evaluate(double[] args)
    {
        if (args.Length != 2)
        {
            throw new ArgumentException("Оператор принимает только 2 аргумента.");
        }

        return Value switch
        {
            "+" => args[0] + args[1],
            "-" => args[0] - args[1],
            "*" => args[0] * args[1],
            "/" => args[0] / args[1],
            "^" => Math.Pow(args[0], args[1]),

            _ => throw new ArgumentException($"Неизвестный оператор: {Value}")
        };
    }
}