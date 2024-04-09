using LogicCalculator.Core.Shared.Interfaces;

namespace LogicCalculator.Core.Shared.Tokenizers;

public class Tokenizer : ITokenizer
{
    private readonly List<(Func<string, int> rule, Func<string, IToken> tokenCreator)> _rules;

    /// <summary>
    /// Конструктор токенизатора, инициализирующий список правил.
    /// </summary>
    /// <param name="initialRules">Начальный набор правил в виде массива кортежей (правило, функция создания токена).</param>
    public Tokenizer((Func<string, int> rule, Func<string, IToken> tokenCreator)[] initialRules)
    {
        _rules = new List<(Func<string, int> rule, Func<string, IToken> tokenCreator)>(initialRules);
    }

    /// <summary>
    /// Метод токенизации выражения.
    /// </summary>
    /// <param name="expression">Входное выражение.</param>
    /// <returns>Список токенов, полученных из выражения.</returns>
    public List<IToken> Tokenize(string expression)
    {
        var tokens = new List<IToken>();
        while (!string.IsNullOrEmpty(expression))
        {
            bool ruleApplied = false; // Переменная для отслеживания применения правила

            foreach (var (rule, tokenCreator) in _rules)
            {
                int size = rule(expression);
                if (size > 0)
                {
                    // Создание токена и добавление его в список токенов
                    tokens.Add(tokenCreator(expression.Substring(0, size)));
                    // Удаление обработанной части выражения
                    expression = expression.Substring(size);
                    ruleApplied = true; // Правило было применено
                    break;
                }
                else if (size <= 0)
                {
                    // Если правило не применяется для текущей подстроки, переходим к следующему
                    continue;
                }
            }

            // Если ни одно правило не было применено и размер равен 0, значит, мы столкнулись с неизвестным символом
            if (!ruleApplied)
            {
                throw new ArgumentException($"Unknown token at position {expression.Length - 1}: {expression}");
            }
        }

        return tokens;
    }
}
