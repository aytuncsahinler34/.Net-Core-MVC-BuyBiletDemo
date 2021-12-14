using Newtonsoft.Json;
using System;

namespace BuyBiletDemo.Core.Models.Requests
{
	public class BusJourneyRequest
	{
		[JsonProperty("data")]
		public DataRequestForJourney DataRequestForJourney { get; set; }
		[JsonProperty("device-session")]
		public DeviceSessionJourney DeviceSessionJourney { get; set; }
		[JsonProperty("date")]
		public DateTime Date { get; set; }
		[JsonProperty("language")]
		public string Language { get; set; } = "en-EN";
	}

	public class DeviceSessionJourney : BaseDeviceSession
	{
	}

	public class DataRequestForJourney
	{
		[JsonProperty("origin-id")]
		public int OriginId { get; set; }
		[JsonProperty("destination-id")]
		public int DestinationId { get; set; }

		[JsonProperty("departure-date")]
		public string DepartureDate { get; set; }
	}
}
