using BuyBiletDemo.Core.Dto;
using BuyBiletDemo.Core.Enums;
using BuyBiletDemo.Core.Helpers;
using BuyBiletDemo.Core.Interfaces;
using BuyBiletDemo.Core.Models.Requests;
using BuyBiletDemo.Core.Models.Responses;
using BuyBiletDemo.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net.Http.Headers;

namespace BuyBiletDemo.UI.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IOBiletIntegrationService _oBiletIntegrationService;

		public HomeController(ILogger<HomeController> logger, IOBiletIntegrationService oBiletIntegrationService) {
			_logger = logger;
			_oBiletIntegrationService = oBiletIntegrationService;
		}

		[HttpGet]
		public IActionResult Index(string fromLocation, string toLocation) 
		{
			var busLocationData = _oBiletIntegrationService.GetBusLocationAsync().Result;
			
			var journeyModel = new JourneyModel() {
				Cities = busLocationData.DataResponseForLocations.Select(x => new CityDto {
					CityId = x.Id,
					CityName = x.Name
				}).ToList()
			};

			ViewBag.Cities = new SelectList(journeyModel.Cities, "CityId", "CityName");
			return View(journeyModel);
			
        }

		public IActionResult Journey() 
		{
			var busLocationData = _oBiletIntegrationService.GetBusLocationAsync().Result;
			
			var busJourneyData = _oBiletIntegrationService.GetBusJourneyAsync().Result;
			var journeyModel = new JourneyModel() {
				Cities = busLocationData.DataResponseForLocations.Select(x => new CityDto {
					CityId = x.Id,
					CityName = x.Name
				}).ToList(),
				Journeys = busJourneyData.DataResponseForJourney.Select(x => new JourneyDto {
					OriginLocationName = x.OriginLocation,
					DestinationLocationName = x.DestinationLocation,
					DepartureTime = x.Journey.Departure.ToString("yyyy-MM-dd"),
					ArrivalTime = x.Journey.Arrival.ToString("yyyy-MM-dd"),
					OriginalPrice = x.Journey.OriginalPrice
				}).ToList()
			};

			ViewBag.Cities = new SelectList(journeyModel.Cities, "CityId", "CityName");
			return View(journeyModel);
			
		}
	}
}
