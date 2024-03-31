using Newtonsoft.Json;

namespace LogicCalculator.ASP.Models.Requests;

public class BaseRequest
{
    [JsonProperty("expression")]
    public string Expression { get; set; }
}