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
                (x => x.StartsWith("+") ? 1 : 0, x => new PlusToken()),
                (x => x.StartsWith("-") ? 1 : 0, x => new MinusToken()),
                (x => x.StartsWith("*") ? 1 : 0, x => new MultiplyToken()),
                (x => x.StartsWith("/") ? 1 : 0, x => new DivideToken()),
                (x => x.StartsWith("(") ? 1 : 0, x => new LeftBracketToken()),
                (x => x.StartsWith(")") ? 1 : 0, x => new RightBracketToken()),
                (x => x.StartsWith("=") ? 1 : 0, x => new EqualsToken()),
                (x => Regex.Match(x, @"^\s+").Success ? Regex.Match(x, @"^\s+").Length : 0, x => new SpaceToken()),
                (x => Regex.Match(x, @"^\d+(\.\d*)?").Success ? Regex.Match(x, @"^\d+(\.\d*)?").Length : 0, x => new NumberToken(double.Parse(x))),
            });
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
                    Result = tokens.Select(token => new TokenResult
                    {
                        Token = token.GetType().Name,
                        Value = token is NumberToken numberToken ? numberToken.Value.ToString() : null
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
