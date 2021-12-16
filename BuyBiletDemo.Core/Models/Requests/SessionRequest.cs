using Newtonsoft.Json;

namespace BuyBiletDemo.Core.Models.Requests
{
	public class SessionRequest
	{
		public string BaseUrl { get; set; }
		public string SchemaName { get; set; }
		public string TokenValue { get; set; }
		public int Type { get; set; }
		public Connection Connection { get; set; }
		public Browser Browser { get; set; }
		public Application Application { get; set; }
	}

	public class Connection
	{
		[JsonProperty("Ip-Address")]
		public string IpAddress { get; set; }
		public string Port { get; set; }
	}

	public class Browser
	{
		public string Name { get; set; }
		public string Version { get; set; }
	}

	public class Application
	{
		public string Version { get; set; }
		[JsonProperty("Equipment-Id")]
		public string EquipmentId { get; set; }
	}
}
