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
                new NumberToken(3),
                new PlusToken(),
                new NumberToken(4),
                new RightBracketToken(),
                new MultiplyToken(),
                new NumberToken(10)
            };

            // Act
            var actualTokens = tokenizer.Tokenize(expression);

            // Assert
            Assert.That(actualTokens.Count, Is.EqualTo(expectedTokens.Count));

            for (int i = 0; i < expectedTokens.Count; i++)
            {
                Assert.IsInstanceOf(expectedTokens[i].GetType(), actualTokens[i]);
                // Дополнительные утверждения могут быть добавлены для проверки свойств токенов, если необходимо
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
                new PlusToken(),
                new NumberToken(1),
            };

            // Act
            var actualTokens = tokenizer.Tokenize(expression);

            // Assert
            Assert.That(actualTokens.Count, Is.EqualTo(expectedTokens.Count));

            for (int i = 0; i < expectedTokens.Count; i++)
            {
                Assert.IsInstanceOf(expectedTokens[i].GetType(), actualTokens[i]);
                // Дополнительные утверждения могут быть добавлены для проверки свойств токенов, если необходимо
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
                new MultiplyToken(),
                new NumberToken(2),
                new RightBracketToken(),
                new DivideToken(),
                new LeftBracketToken(),
                new NumberToken(1),
                new PlusToken(),
                new NumberToken(3),
                new MinusToken(),
                new NumberToken(4),
                new RightBracketToken(),
            };

            // Act
            var actualTokens = tokenizer.Tokenize(expression);

            // Assert
            Assert.That(actualTokens.Count, Is.EqualTo(expectedTokens.Count));

            for (int i = 0; i < expectedTokens.Count; i++)
            {
                Assert.IsInstanceOf(expectedTokens[i].GetType(), actualTokens[i]);
                // Дополнительные утверждения могут быть добавлены для проверки свойств токенов, если необходимо
            }
        }

        [Test]
        public void TokenizeTest04()
        {
            // Arrange
            ITokenizer tokenizer = new Tokenizer(TokenizerTestRules.DefaultRules);

            // Выражение содержит неизвестный токен "="
            string expression = "(3 + 4) = 5";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => tokenizer.Tokenize(expression));
        }
    }

    public static class TokenizerTestRules
    {
        // Правила, чтобы не писать их заново в каждом тесте
        public static readonly (Func<string, int> rule, Func<string, IToken> tokenCreator)[] DefaultRules = new (Func<string, int> rule, Func<string, IToken> tokenCreator)[]
        {
            (x => x.StartsWith("+") ? 1 : 0, x => new PlusToken()),
            (x => x.StartsWith("-") ? 1 : 0, x => new MinusToken()),
            (x => x.StartsWith("*") ? 1 : 0, x => new MultiplyToken()),
            (x => x.StartsWith("/") ? 1 : 0, x => new DivideToken()),
            (x => x.StartsWith("(") ? 1 : 0, x => new LeftBracketToken()),
            (x => x.StartsWith(")") ? 1 : 0, x => new RightBracketToken()),
            (x => char.IsDigit(x[0]) ? GetNumberLength(x) : 0, x => new NumberToken(double.Parse(x)))
            // Тип токена для пробела не существует
            // При неизвестном токене, он по идеи 
        };

        // Вспомогательный метод для определения длины числа в строке
        private static int GetNumberLength(string input)
        {
            int length = 0;
            foreach (char c in input)
            {
                if (char.IsDigit(c) || c == '.')
                {
                    length++;
                }
                else
                {
                    break;
                }
            }
            return length;
        }
    }
}