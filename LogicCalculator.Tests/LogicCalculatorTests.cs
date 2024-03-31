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

            // ��������� ��� ������������
            string expression = "( 3 + 4 ) * 10";

            // ��������� ������
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

            // ��������� ��� ������������
            string expression = "10/5 + 1";

            // ��������� ������
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

            // ��������� ��� ������������
            string expression = "(2 * 2) / (1 + 3 - 2)";

            // ��������� ������
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

            // ��������� �������� ����������� ����� "="
            string expression = "(3 + 4) = 5";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => tokenizer.Tokenize(expression));
        }

        [Test]
        public void TokenizeTest05()
        {
            // Arrange
            ITokenizer tokenizer = new Tokenizer(TokenizerTestRules.DefaultRules);

            // ��������� ��� ������������
            string expression = "2+2*2";

            // ��������� ������
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

            // ��������� ��� ������������
            string expression = "2+2*2=6";

            // ��������� ������
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

            // ��������� ��� ������������
            string expression = "(2 * 2) + 10 = 14";

            // ��������� ������
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
        // �������, ����� �� ������ �� ������ � ������ �����
        // � ���������
        public static readonly (Func<string, int> rule, Func<string, IToken> tokenCreator)[] DefaultRules = new (Func<string, int> rule, Func<string, IToken> tokenCreator)[]
        {
            (x => x.StartsWith("+") ? 1 : 0, x => new PlusToken()),
            (x => x.StartsWith("-") ? 1 : 0, x => new MinusToken()),
            (x => x.StartsWith("*") ? 1 : 0, x => new MultiplyToken()),
            (x => x.StartsWith("/") ? 1 : 0, x => new DivideToken()),
            (x => x.StartsWith("(") ? 1 : 0, x => new LeftBracketToken()),
            (x => x.StartsWith(")") ? 1 : 0, x => new RightBracketToken()),
            (x => x.StartsWith(" ") ? 1 : 0, x => new SpaceToken()),
            (x => x.StartsWith("=") ? 1 : 0, x => new EqualsToken()),
            (x => char.IsDigit(x[0]) ? GetNumberLength(x) : 0, x => new NumberToken(double.Parse(x)))
        };

        // ������� ��� �������� �� ������ ������
        // � ������ �� ��������������
        public static readonly (Func<string, int> rule, Func<string, IToken> tokenCreator)[] RulesWithoutSpace = new (Func<string, int> rule, Func<string, IToken> tokenCreator)[]
        {
            (x => x.StartsWith("+") ? 1 : 0, x => new PlusToken()),
            (x => x.StartsWith("-") ? 1 : 0, x => new MinusToken()),
            (x => x.StartsWith("*") ? 1 : 0, x => new MultiplyToken()),
            (x => x.StartsWith("/") ? 1 : 0, x => new DivideToken()),
            (x => x.StartsWith("(") ? 1 : 0, x => new LeftBracketToken()),
            (x => x.StartsWith(")") ? 1 : 0, x => new RightBracketToken()),
            (x => x.StartsWith("=") ? 1 : 0, x => new EqualsToken()),
            (x => char.IsDigit(x[0]) ? GetNumberLength(x) : 0, x => new NumberToken(double.Parse(x)))
        };

        // ��������������� ����� ��� ����������� ����� ����� � ������
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