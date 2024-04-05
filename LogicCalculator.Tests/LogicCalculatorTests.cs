using LogicCalculator.Core.Shared.Interfaces;
using LogicCalculator.Core.Shared.Tokenizers;
using LogicCalculator.Core.Shared.Tokens;
using System.Text.RegularExpressions;

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

    [TestFixture]
    public class TokenizerTests
    {
        [Test]
        public void TokenizeTest01()
        {
            // Arrange
            ITokenizer tokenizer = new Tokenizer(TokenizerTestRules.DefaultRules);

            // Выражение для тестирования
            string expression = "( 3 + 4 ) * 10";

            // Ожидаемые токены
            var expectedTokens = new List<IToken>
            {
                new LeftBracketToken(),
                new SpaceToken(),
                new NumberToken(3),
                new SpaceToken(),
                new PlusToken(),
                new SpaceToken(),
                new NumberToken(4),
                new SpaceToken(),
                new RightBracketToken(),
                new SpaceToken(),
                new MultiplyToken(),
                new SpaceToken(),
                new NumberToken(10)
            };

            // Act
            var actualTokens = tokenizer.Tokenize(expression);

            // Assert
            Assert.That(actualTokens.Count, Is.EqualTo(expectedTokens.Count));

            for (int i = 0; i < expectedTokens.Count; i++)
            {
                Assert.IsInstanceOf(expectedTokens[i].GetType(), actualTokens[i]);
            }
        }

        [Test]
        public void TokenizeTest02()
        {
            // Arrange
            ITokenizer tokenizer = new Tokenizer(TokenizerTestRules.DefaultRules);

            // Выражение для тестирования
            string expression = "10/5 + 1";

            // Ожидаемые токены
            var expectedTokens = new List<IToken>
            {
                new NumberToken(10),
                new DivideToken(),
                new NumberToken(5),
                new SpaceToken(),
                new PlusToken(),
                new SpaceToken(),
                new NumberToken(1),
            };

            // Act
            var actualTokens = tokenizer.Tokenize(expression);

            // Assert
            Assert.That(actualTokens.Count, Is.EqualTo(expectedTokens.Count));

            for (int i = 0; i < expectedTokens.Count; i++)
            {
                Assert.IsInstanceOf(expectedTokens[i].GetType(), actualTokens[i]);
            }
        }

        [Test]
        public void TokenizeTest03()
        {
            // Arrange
            ITokenizer tokenizer = new Tokenizer(TokenizerTestRules.DefaultRules);

            // Выражение для тестирования
            string expression = "(2 * 2) / (1 + 3 - 2)";

            // Ожидаемые токены
            var expectedTokens = new List<IToken>
            {
                new LeftBracketToken(),
                new NumberToken(2),
                new SpaceToken(),
                new MultiplyToken(),
                new SpaceToken(),
                new NumberToken(2),
                new RightBracketToken(),
                new SpaceToken(),
                new DivideToken(),
                new SpaceToken(),
                new LeftBracketToken(),
                new NumberToken(1),
                new SpaceToken(),
                new PlusToken(),
                new SpaceToken(),
                new NumberToken(3),
                new SpaceToken(),
                new MinusToken(),
                new SpaceToken(),
                new NumberToken(2),
                new RightBracketToken(),
            };

            // Act
            var actualTokens = tokenizer.Tokenize(expression);

            // Assert
            Assert.That(actualTokens.Count, Is.EqualTo(expectedTokens.Count));

            for (int i = 0; i < expectedTokens.Count; i++)
            {
                Assert.IsInstanceOf(expectedTokens[i].GetType(), actualTokens[i]);
            }
        }

        [Test]
        public void TokenizeTest04()
        {
            // Arrange
            ITokenizer tokenizer = new Tokenizer(TokenizerTestRules.DefaultRules);

            // Выражение содержит неизвестный токен "!"
            string expression = "2 + 3 ! 5";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => tokenizer.Tokenize(expression));
        }

        [Test]
        public void TokenizeTest05()
        {
            // Arrange
            ITokenizer tokenizer = new Tokenizer(TokenizerTestRules.DefaultRules);

            // Выражение для тестирования
            string expression = "2+2*2";

            // Ожидаемые токены
            var expectedTokens = new List<IToken>
            {
                new NumberToken(2),
                new PlusToken(),
                new NumberToken(2),
                new MultiplyToken(),
                new NumberToken(2),
            };

            // Act
            var actualTokens = tokenizer.Tokenize(expression);

            // Assert
            Assert.That(actualTokens.Count, Is.EqualTo(expectedTokens.Count));

            for (int i = 0; i < expectedTokens.Count; i++)
            {
                Assert.IsInstanceOf(expectedTokens[i].GetType(), actualTokens[i]);
            }
        }

        [Test]
        public void TokenizeTest06()
        {
            // Arrange
            ITokenizer tokenizer = new Tokenizer(TokenizerTestRules.DefaultRules);

            // Выражение для тестирования
            string expression = "2+2*2=6";

            // Ожидаемые токены
            var expectedTokens = new List<IToken>
            {
                new NumberToken(2),
                new PlusToken(),
                new NumberToken(2),
                new MultiplyToken(),
                new NumberToken(2),
                new EqualsToken(),
                new NumberToken(6)
            };

            // Act
            var actualTokens = tokenizer.Tokenize(expression);

            // Assert
            Assert.That(actualTokens.Count, Is.EqualTo(expectedTokens.Count));

            for (int i = 0; i < expectedTokens.Count; i++)
            {
                Assert.IsInstanceOf(expectedTokens[i].GetType(), actualTokens[i]);
            }
        }

        [Test]
        public void TokenizeTest07()
        {
            // Arrange
            ITokenizer tokenizer = new Tokenizer(TokenizerTestRules.DefaultRules);

            // Выражение для тестирования
            string expression = "(2 * 2) + 10 = 14";

            // Ожидаемые токены
            var expectedTokens = new List<IToken>
            {
                new LeftBracketToken(),
                new NumberToken(2),
                new SpaceToken(),
                new MultiplyToken(),
                new SpaceToken(),
                new NumberToken(2),
                new RightBracketToken(),
                new SpaceToken(),
                new PlusToken(),
                new SpaceToken(),
                new NumberToken(10),
                new SpaceToken(),
                new EqualsToken(),
                new SpaceToken(),
                new NumberToken(14),
            };

            // Act
            var actualTokens = tokenizer.Tokenize(expression);

            // Assert
            Assert.That(actualTokens.Count, Is.EqualTo(expectedTokens.Count));

            for (int i = 0; i < expectedTokens.Count; i++)
            {
                Assert.IsInstanceOf(expectedTokens[i].GetType(), actualTokens[i]);
            }
        }
    }

    public static class TokenizerTestRules
    {
        // Правила, чтобы не писать их заново в каждом тесте
        public static readonly (Func<string, int> rule, Func<string, string, int, IToken> tokenCreator, string tokenType, int priority)[] DefaultRules =
        {
            (x => x.StartsWith("+") ? 1 : 0, (x, type, priority) => new PlusToken(), "Operator", 2),
            (x => x.StartsWith("-") ? 1 : 0, (x, type, priority) => new MinusToken(), "Operator", 2),
            (x => x.StartsWith("*") ? 1 : 0, (x, type, priority) => new MultiplyToken(), "Operator", 3),
            (x => x.StartsWith("/") ? 1 : 0, (x, type, priority) => new DivideToken(), "Operator", 3),
            (x => x.StartsWith("(") ? 1 : 0, (x, type, priority) => new LeftBracketToken(), "LeftBracket", 0),
            (x => x.StartsWith(")") ? 1 : 0, (x, type, priority) => new RightBracketToken(), "RightBracket", 0),
            (x => x.StartsWith("=") ? 1 : 0, (x, type, priority) => new EqualsToken(), "Operator", 0),
            (x => Regex.Match(input: x, pattern: @"^\s+").Success ?
                Regex.Match(input: x, pattern: @"^\s+").Length : 0, (x, type, priority) => new SpaceToken(), "Space", 0),
            (x => Regex.Match(input: x, pattern: @"^\d+(\.\d*)?").Success ?
                Regex.Match(input: x, pattern: @"^\d+(\.\d*)?").Length :0, (x, type, priority) => new NumberToken(double.Parse(x)), "Variable", 0),
        };
    }
}