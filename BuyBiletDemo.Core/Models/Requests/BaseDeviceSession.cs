using Newtonsoft.Json;

namespace BuyBiletDemo.Core.Models.Requests
{
	public class BaseDeviceSession
	{
		[JsonProperty("session-id")]
		public string SessionId { get; set; }
		[JsonProperty("device-id")]
		public string DeviceId { get; set; }
		
	}
}
