using Newtonsoft.Json;

namespace LogicCalculator.ASP.Models.Responses;

public class BaseResponse
{
    [JsonProperty("result")]
    public string? Result { get; set; }
}