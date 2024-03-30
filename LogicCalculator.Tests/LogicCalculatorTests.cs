using LogicCalculator.Core.Shared.Interfaces;
using LogicCalculator.Core.Shared.Tokenizers;
using LogicCalculator.Core.Shared.Tokens;

namespace LogicCalculator.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    /// <summary>
    /// Проверяет, что правильно токенизируется арифметическое выражение.
    /// </summary>
    [Test]
    public void ArithmeticTokenizer_Test_01()
    {
        // Arrange
        var tokenizer = new ArithmeticTokenizer(new Func<string, (IToken, int)>[]
        {
                x => x.StartsWith("+") ? ((IToken)new PlusToken(), 1) : (new NumberToken(0), 0),
                x => x.StartsWith("-") ? ((IToken)new MinusToken(), 1) : (new NumberToken(0), 0),
                x => double.TryParse(x, out double number) ? ((IToken)new NumberToken(number), x.Length) : (new NumberToken(0), 0),
        });

        // Act
        var tokens = tokenizer.Tokenize("1 + 2 - 3.5");

        // Assert
        Assert.That(tokens.Count, Is.EqualTo(5));
        Assert.That(tokens[0], Is.InstanceOf<NumberToken>());
        Assert.That(tokens[1], Is.InstanceOf<PlusToken>());
        Assert.That(tokens[2], Is.InstanceOf<NumberToken>());
        Assert.That(tokens[3], Is.InstanceOf<MinusToken>());
        Assert.That(tokens[4], Is.InstanceOf<NumberToken>());
    }

    /// <summary>
    /// Проверяет, что токенизатор выбрасывает исключение для выражения с неизвестным символом.
    /// </summary>
    [Test]
    public void ArithmeticTokenizer_Test_03()
    {
        // Arrange
        var tokenizer = new ArithmeticTokenizer(new Func<string, (IToken, int)>[]
        {
                x => x.StartsWith("+") ? ((IToken)new PlusToken(), 1) : (new NumberToken(0), 0),
                x => x.StartsWith("-") ? ((IToken)new MinusToken(), 1) : (new NumberToken(0), 0),
                x => double.TryParse(x, out double number) ? ((IToken)new NumberToken(number), x.Length) : (new NumberToken(0), 0),
        });

        // Act & Assert
        Assert.Throws<ArgumentException>(() => tokenizer.Tokenize("1 + 2 & 3.5"));
    }

    /// <summary>
    /// Проверяет, что для пустого выражения возвращается пустой список токенов.
    /// </summary>
    [Test]
    public void ArithmeticTokenizer_Test_02()
    {
        // Arrange
        var tokenizer = new ArithmeticTokenizer(new Func<string, (IToken, int)>[]
        {
                x => x.StartsWith("+") ? ((IToken)new PlusToken(), 1) : (new NumberToken(0), 0),
                x => x.StartsWith("-") ? ((IToken)new MinusToken(), 1) : (new NumberToken(0), 0),
                x => double.TryParse(x, out double number) ? ((IToken)new NumberToken(number), x.Length) : (new NumberToken(0), 0),
        });

        // Act
        var tokens = tokenizer.Tokenize("");

        // Assert
        Assert.IsEmpty(tokens);
    }
}