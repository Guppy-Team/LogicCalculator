namespace LogicCalculator.Core;

/// <summary>
/// Представляет собой токен в математическом выражении, включая его тип, значение и приоритет.
/// </summary>
public class Token
{
    public TokenType Type { get; }
    public string Value { get; }
    private int Precedence { get; }

    /// <summary>
    /// Создаёт новый экземпляр класса <see cref="Token"/> с данными типом, значением и приоритетом.
    /// </summary>
    /// <param name="type">Тип токена.</param>
    /// <param name="value">Значение токена.</param>
    /// <param name="precedence">Приоритет токена.</param>
    public Token(TokenType type, string value, int precedence)
    {
        Type = type;
        Value = value;
        Precedence = precedence;
    }

    /// <summary>
    /// Определяет, равен ли данный объект токену.
    /// </summary>
    /// <param name="obj">Объект для сравнения.</param>
    /// <returns>True, если объект равен данному токену, иначе - False.</returns>
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Token other = (Token)obj;
        return Type == other.Type && Value == other.Value && Precedence == other.Precedence;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Type, Value, Precedence);
    }

    /// <summary>
    /// Возвращает строковое представление токена, включая его тип, значение и приоритет.
    /// </summary>
    /// <returns>Строковое представление токена.</returns>
    public override string ToString()
    {
        return $"Type: {Type}, Value: {Value}, Precedence: {Precedence}";
    }
}

public enum TokenType
{
    Number,
    Operator,
    LeftBracket,
    RightBracket,
    Variable,
    Function,
}