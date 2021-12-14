using Newtonsoft.Json;

namespace BuyBiletDemo.Core.Models.Responses
{
	public class BaseResponse
	{
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("userMessage")]
        public string UserMessage { get; set; }
        [JsonProperty("apirequestid")]
        public int? ApiRequestId { get; set; }
        [JsonProperty("controller")]
        public string Controller { get; set; }
    }
}
