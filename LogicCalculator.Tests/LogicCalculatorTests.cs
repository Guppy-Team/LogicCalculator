using System.Text.RegularExpressions;
using LogicCalculator.Core.Shared.Interfaces;
using LogicCalculator.Core.Shared.Tokenizers;
using LogicCalculator.Core.Shared.Tokens;

namespace LogicCalculator.Tests;

public class Tests
{
    private static readonly (Func<string, int>, Func<string, IToken>)[] _defaultRules =
    [
        (x => x.StartsWith("+") ? 1 : 0, x => new PlusToken()),
        (x => x.StartsWith("-") ? 1 : 0, x => new MinusToken()),
        (x => x.StartsWith("*") ? 1 : 0, x => new MultiplyToken()),
        (x => x.StartsWith("/") ? 1 : 0, x => new DivideToken()),
        (x => x.StartsWith("(") ? 1 : 0, x => new LeftBracketToken()),
        (x => x.StartsWith(")") ? 1 : 0, x => new RightBracketToken()),
        (x => Regex.Match(x, @"^\s+").Success ? Regex.Match(x, @"^\s+").Length : 0, x => new SpaceToken()),
        (x => Regex.Match(x, @"^\d+(\.\d*)?").Success ? Regex.Match(x, @"^\d+(\.\d*)?").Length : 0, x => new NumberToken(double.Parse(x))),
        (x => x.StartsWith("=") ? 1 : 0, x => new EqualsToken())
    ];

    private static readonly ITokenizer _tokenizer = new Tokenizer(_defaultRules);

    [TestFixture]
    public class TokenizerTests
    {
        [Test]
        public void TokenizeTest01()
        {
            string expression = "( 3 + 4 ) * 10";

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

            var actualTokens = _tokenizer.Tokenize(expression);

            Assert.That(actualTokens.Count, Is.EqualTo(expectedTokens.Count));

            for (int i = 0; i < expectedTokens.Count; i++)
            {
                Assert.IsInstanceOf(expectedTokens[i].GetType(), actualTokens[i]);
            }
        }

        [Test]
        public void TokenizeTest02()
        {
            string expression = "10/5 + 1";

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

            var actualTokens = _tokenizer.Tokenize(expression);

            Assert.That(actualTokens.Count, Is.EqualTo(expectedTokens.Count));

            for (int i = 0; i < expectedTokens.Count; i++)
            {
                Assert.IsInstanceOf(expectedTokens[i].GetType(), actualTokens[i]);
            }
        }

        [Test]
        public void TokenizeTest03()
        {
            string expression = "(2 * 2) / (1 + 3 - 2)";

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

            var actualTokens = _tokenizer.Tokenize(expression);

            Assert.That(actualTokens.Count, Is.EqualTo(expectedTokens.Count));

            for (int i = 0; i < expectedTokens.Count; i++)
            {
                Assert.IsInstanceOf(expectedTokens[i].GetType(), actualTokens[i]);
            }
        }

        [Test]
        public void TokenizeTest04()
        {
            string expression = "2 + 3 ! 5";

            Assert.Throws<ArgumentException>(() => _tokenizer.Tokenize(expression));
        }

        [Test]
        public void TokenizeTest05()
        {
            string expression = "2+2*2";

            var expectedTokens = new List<IToken>
            {
                new NumberToken(2),
                new PlusToken(),
                new NumberToken(2),
                new MultiplyToken(),
                new NumberToken(2),
            };

            var actualTokens = _tokenizer.Tokenize(expression);

            Assert.That(actualTokens.Count, Is.EqualTo(expectedTokens.Count));

            for (int i = 0; i < expectedTokens.Count; i++)
            {
                Assert.IsInstanceOf(expectedTokens[i].GetType(), actualTokens[i]);
            }
        }

        [Test]
        public void TokenizeTest06()
        {
            string expression = "2+2*2=6";

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

            var actualTokens = _tokenizer.Tokenize(expression);

            Assert.That(actualTokens.Count, Is.EqualTo(expectedTokens.Count));

            for (int i = 0; i < expectedTokens.Count; i++)
            {
                Assert.IsInstanceOf(expectedTokens[i].GetType(), actualTokens[i]);
            }
        }

        [Test]
        public void TokenizeTest07()
        {
            string expression = "(2 * 2) + 10 = 14";

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

            var actualTokens = _tokenizer.Tokenize(expression);

            Assert.That(actualTokens.Count, Is.EqualTo(expectedTokens.Count));

            for (int i = 0; i < expectedTokens.Count; i++)
            {
                Assert.IsInstanceOf(expectedTokens[i].GetType(), actualTokens[i]);
            }
        }
    }
}