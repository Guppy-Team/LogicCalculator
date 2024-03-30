using LogicCalculator.Core.Shared.Interfaces;
using LogicCalculator.Core.Shared.Tokens;
using System.Data;

namespace LogicCalculator.Core.Shared.Tokenizers;

// TODO Переделать под новую структуру 
public class ArithmeticTokenizer : ITokenizer
{
    private readonly Func<string, (IToken token, int size)>[] _rules;

    /// <summary>
    /// Конструктор токенизатора, принимающий массив правил для разбора выражения.
    /// </summary>
    /// <param name="rules">Массив правил для разбора выражения.</param>
    public ArithmeticTokenizer(Func<string, (IToken token, int size)>[] rules)
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
                var (token, size) = rule(expression);
                if (size > 0)
                {
                    // Создание токена и добавление его в список токенов
                    tokens.Add(token);
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
            }

            // Если ни одно правило не было применено, значит, мы столкнулись с неизвестным символом
            if (!ruleApplied)
            {
                throw new ArgumentException($"Unknown token at position {expression.Length - 1}: {expression}");
            }
        }

        return tokens;
    }
}