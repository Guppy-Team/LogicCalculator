using LogicCalculator.Core.Shared.Interfaces;
using LogicCalculator.Core.Shared.Tokens;
using System.Data;

namespace LogicCalculator.Core.Shared.Tokenizers;

// TODO Переделать под новую структуру 
public class ArithmeticTokenizer : ITokenizer
{
    private readonly Func<string, int>[] _rules;

    /// <summary>
    /// Конструктор токенизатора, принимающий массив правил для разбора выражения.
    /// </summary>
    /// <param name="rules">Массив правил для разбора выражения.</param>
    public ArithmeticTokenizer(Func<string, int>[] rules)
    {
        _rules = rules;
    }

    /// <summary>
    /// Метод токенизации арифметического выражения.
    /// </summary>
    /// <param name="expression">Входное арифметическое выражение.</param>
    /// <returns>Список токенов, полученных из выражения.</returns>
    public List<IToken> Tokenize(string expression)
    {
        var tokens = new List<IToken>();
        while (!string.IsNullOrEmpty(expression))
        {
            bool ruleApplied = false; // Переменная для отслеживания применения правила

            foreach (var rule in _rules)
            {
                var size = rule(expression);
                if (size > 0)
                {
                    // Создание токена и добавление его в список токенов
                    tokens.Add(CreateToken(expression.Substring(0, size)));
                    // Удаление обработанной части выражения
                    expression = expression.Substring(size);
                    ruleApplied = true; // Правило было применено
                    break;
                }
                else if (size == -1)
                {
                    // Если правило не применяется для текущей подстроки, переходим к следующему
                    ruleApplied = true;
                    break;
                }
                else if (size == 0)
                {
                    // Пропуск правила, если его размер равен 0
                    continue;
                }
            }

            // Если ни одно правило не было применено, значит, мы столкнулись с неизвестным символом
            if (!ruleApplied)
            {
                throw new ArgumentException($"Unknown token at position {expression.Length - 1}: {expression}");
            }
        }

        return tokens;
    }

    /// <summary>
    /// Создает токен на основе значения.
    /// </summary>
    /// <param name="tokenValue">Значение токена.</param>
    /// <returns>Токен, созданный на основе значения.</returns>
    private IToken CreateToken(string tokenValue)
    {
        switch (tokenValue)
        {
            case "+":
                return new PlusToken();
            case "-":
                return new MinusToken();
            case "*":
                return new MultiplyToken();
            case "/":
                return new DivideToken();
            case "(":
                return new LeftBracketToken();
            case ")":
                return new RightBracketToken();
            default:
                if (double.TryParse(tokenValue, out double number))
                {
                    // Создание токена числа
                    return new NumberToken(number);
                }
                else
                {
                    // Если значение не соответствует ни одному известному токену, генерируется исключение
                    throw new ArgumentException($"Unknown token: {tokenValue}");
                }
        }
    }
}