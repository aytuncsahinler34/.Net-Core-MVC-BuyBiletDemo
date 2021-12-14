using Newtonsoft.Json;

namespace BuyBiletDemo.Core.Models.Responses
{
	public class SessionResponse : BaseResponse
	{
        [JsonProperty("data")]
        public DataResponseForSession Data { get; set; }
    }

    public class DataResponseForSession
	{
        [JsonProperty("session-id")]
        public string SessionId { get; set; }
        [JsonProperty("device-id")]
        public string DeviceId { get; set; }
    }
}
