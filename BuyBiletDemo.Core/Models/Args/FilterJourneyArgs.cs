using System;

namespace BuyBiletDemo.Core.Models.Args
{
	public class FilterJourneyArgs
	{
		public int FromLocationId { get; set; }
		public int ToLocationId { get; set; }
		public DateTime DateTime { get; set; }
	}
}
