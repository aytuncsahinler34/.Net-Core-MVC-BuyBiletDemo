using Newtonsoft.Json;
using System.Collections.Generic;

namespace BuyBiletDemo.Core.Models.Responses
{
	public class BusLocationsResponse : BaseResponse
	{
		[JsonProperty("data")]
		public List<DataResponseForLocations> DataResponseForLocations { get; set; }
	}

	public class DataResponseForLocations
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("parent-id")]
		public int? ParentId { get; set; }
		[JsonProperty("type")]
		public string Type { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("geo-location")]
		public GeoLocation GeoLocation { get; set; }
		[JsonProperty("tz-code")]
		public string TzCode { get; set; }
		[JsonProperty("weather-code")]
		public string WeatherCode { get; set; }
		[JsonProperty("reference-code")]
		public string ReferenceCode { get; set; }
		[JsonProperty("rank")]
		public int? Rank { get; set; }
		[JsonProperty("keywords")]
		public string Keywords { get; set; }
		[JsonProperty("zoom")]
		public string Zoom { get; set; }
	}

	public class GeoLocation
	{
		[JsonProperty("latitude")]
		public double? Latitude { get; set; }
		[JsonProperty("longitude")]
		public double? Longitude { get; set; }
		[JsonProperty("zoom")]
		public string Zoom { get; set; }
	}
}
