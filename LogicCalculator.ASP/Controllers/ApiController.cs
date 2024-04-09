using System.Globalization;
using System.Text.RegularExpressions;
using LogicCalculator.ASP.Dtos;
using LogicCalculator.Core.Shared.Interfaces;
using LogicCalculator.Core.Shared.Tokenizers;
using LogicCalculator.Core.Shared.Tokens;
using Microsoft.AspNetCore.Mvc;

namespace LogicCalculator.ASP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ITokenizer _tokenizer;

        public ApiController()
        {
            _tokenizer = new Tokenizer(new (Func<string, int>, Func<string, IToken>)[]
            {
                (x => x.StartsWith("+") ? 1 : 0, _ => new PlusToken()),
                (x => x.StartsWith("-") ? 1 : 0, _ => new MinusToken()),
                (x => x.StartsWith("*") ? 1 : 0, _ => new MultiplyToken()),
                (x => x.StartsWith("/") ? 1 : 0, _ => new DivideToken()),
                (x => x.StartsWith("(") ? 1 : 0, _ => new LeftBracketToken()),
                (x => x.StartsWith(")") ? 1 : 0, _ => new RightBracketToken()),
                (x => x.StartsWith("=") ? 1 : 0, _ => new EqualsToken()),
                (x => GetMatchLength(x, @"^\s+"), x => new SpaceToken()),
                // NumberStyles.Number, CultureInfo.InvariantCulture добавлены,
                // чтобы избавиться от приколов с точками и запятыми
                (x => GetMatchLength(x, @"^\d+([,.]\d*)?"), x => new NumberToken(double.Parse(x, NumberStyles.Number, CultureInfo.InvariantCulture))),
            });
        }

        private int GetMatchLength(string input, string pattern)
        {
            var match = Regex.Match(input, pattern);
            return match.Success ? match.Length : 0;
        }

        [HttpPost]
        [Route("tokenize")]
        public IActionResult Tokenize([FromBody] ExpressionRequest request)
        {
            try
            {
                var tokens = _tokenizer.Tokenize(request.Expression);
                var response = new TokenizeResponse
                {
                    Result = tokens.Select(token =>
                    {
                        var tokenType = token.GetType();
                        var valueProperty = tokenType.GetProperty("Value");
                        var value = valueProperty != null ? valueProperty.GetValue(token)?.ToString() : null;

                        return new TokenResult
                        {
                            Token = tokenType.Name,
                            Value = value
                        };
                    }).ToList()
                };
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}