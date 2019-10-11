using Newtonsoft.Json;

namespace DinosaurusPark.WebApplication.Responses
{
    public class ErrorResponse
    {
        public ErrorResponse(string code, string message = null)
        {
            Code = code;
            Message = message;
        }

        public string Code { get; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Message { get; }
    }
}
