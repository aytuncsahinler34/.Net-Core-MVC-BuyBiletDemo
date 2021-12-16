namespace BuyBiletDemo.Core.Dto
{
	public class JourneyDto
	{
		public string OriginLocationName { get; set; }
		public string DestinationLocationName { get; set; }
		public string DepartureTime { get; set; }
		public string ArrivalTime { get; set; }
		public decimal OriginalPrice { get; set; }
	}
}
