using Newtonsoft.Json;
using System;

namespace BuyBiletDemo.Core.Models.Requests
{
	public class BusLocationsRequest
	{
		[JsonProperty("data")]
		public string DataRequestForLocation { get; set; }
		[JsonProperty("device-session")]
		public DeviceSessionLocation DeviceSessionLocation { get; set; }
		[JsonProperty("date")]
		public DateTime Date { get; set; }
		[JsonProperty("language")]
		public  string Language { get; set; } = "en-EN";
	}

	public class DeviceSessionLocation : BaseDeviceSession
	{
	}
}
