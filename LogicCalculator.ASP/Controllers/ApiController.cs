using System.Text;
using LogicCalculator.ASP.Models.Requests;
using LogicCalculator.ASP.Models.Responses;
using LogicCalculator.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace LogicCalculator.ASP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        [HttpGet("ping")]
        public IActionResult Ping()
        {
            var response = new BaseResponse
            {
                Result = "Pong"
            };

            return Ok(response);
        }

        [HttpPost("ConvertToRpn")]
        public IActionResult ConvertToRpn([FromBody] BaseRequest request)
        {
            var tokens = Lexer.Tokenize(request.Expression);
            var rpnTokens = Lexer.ConvertToRpn(tokens);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < rpnTokens.Count; i++)
            {
                sb.Append(rpnTokens[i].Value);

                if (i < rpnTokens.Count - 1)
                {
                    sb.Append(' ');
                }
            }

            string result = sb.ToString();

            var response = new BaseResponse
            {
                Result = result
            };

            return Ok(response);
        }
    }
}
