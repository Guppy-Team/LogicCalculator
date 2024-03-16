using LogicCalculator.Core.Shared.Interfaces;

namespace LogicCalculator.Core.Shared.Tokens;

public class FunctionToken : IToken
{
    public TokenType Type => TokenType.Function;
    public string Value { get; }

    public int Priority => 5;

    public FunctionToken(string value)
    {
        Value = value;
    }

    public double Evaluate(double[] args)
    {
        if (args.Length != 1)
        {
            throw new ArgumentException("Функция принимает только один аргумент.");
        }

        return Value switch
        {
            "sin" => Math.Sin(args[0]),
            "cos" => Math.Cos(args[0]),
            "tan" => Math.Tan(args[0]),
            "sqrt" => Math.Sqrt(args[0]),

            _ => throw new ArgumentException($"Неизвестная функция: {Value}")
        };
    }
}