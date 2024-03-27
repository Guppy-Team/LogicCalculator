using System.Text;
using LogicCalculator.ASP.Models.Requests;
using LogicCalculator.ASP.Models.Responses;
using LogicCalculator.Core.Shared.ExpressionEvaluators;
using LogicCalculator.Core.Shared.Tokenizers;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

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
            var tokenizer = new ArithmeticTokenizer();
            var rpnConverter = new RpnConverter();
            var tokens = tokenizer.Tokenize(request.Expression);
            var rpnTokens = rpnConverter.Convert(tokens);

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