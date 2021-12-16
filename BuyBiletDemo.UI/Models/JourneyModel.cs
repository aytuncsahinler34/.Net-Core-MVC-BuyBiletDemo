using BuyBiletDemo.Core.Dto;
using System.Collections.Generic;

namespace BuyBiletDemo.UI.Models
{
	public class JourneyModel
	{
        public List<CityDto> Cities { get; set; }
        public List<JourneyDto> Journeys { get; set; }
    }
}
