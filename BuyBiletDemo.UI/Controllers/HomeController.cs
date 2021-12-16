using BuyBiletDemo.Core.Dto;
using BuyBiletDemo.Core.Interfaces;
using BuyBiletDemo.Core.Models.Args;
using BuyBiletDemo.Core.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace BuyBiletDemo.UI.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IOBiletIntegrationService _oBiletIntegrationService;
		private readonly SessionRequest _appIdentitySettings;

		public HomeController(ILogger<HomeController> logger, IOBiletIntegrationService oBiletIntegrationService, IOptions<SessionRequest> appIdentitySettingsAccessor) {
			_logger = logger;
			_oBiletIntegrationService = oBiletIntegrationService;
			_appIdentitySettings = appIdentitySettingsAccessor.Value;
		}

		[HttpGet]
		public IActionResult Index() 
		{
			var busLocationData = _oBiletIntegrationService.GetBusLocationAsync(_appIdentitySettings).Result;

			var cities = busLocationData.DataResponseForLocations.Select(x => new CityDto {
				CityId = x.Id,
				CityName = x.Name
			}).ToList();

			ViewBag.Cities = new SelectList(cities, "CityId", "CityName");
			return View();
			
        }

		[HttpGet]
		public IActionResult Journey(int fromLocation, int toLocation, DateTime dateTime) 
		{
			FilterJourneyArgs filterJourneyArgs = new FilterJourneyArgs();
			filterJourneyArgs.FromLocationId = fromLocation;
			filterJourneyArgs.ToLocationId = toLocation;
			filterJourneyArgs.DateTime = dateTime;

			var busJourneyData = _oBiletIntegrationService.GetBusJourneyAsync(_appIdentitySettings, filterJourneyArgs).Result;

			if (busJourneyData.DataResponseForJourney != null) 
			{
				var journeys = busJourneyData.DataResponseForJourney.OrderBy(x => x.Journey.Departure).Select(x => new JourneyDto {
					OriginLocationName = x.OriginLocation,
					DestinationLocationName = x.DestinationLocation,
					DepartureTime = x.Journey.Departure.ToString("yyyy-MM-dd hh:ss"),
					ArrivalTime = x.Journey.Arrival.ToString("yyyy-MM-dd hh:ss"),
					OriginalPrice = x.Journey.OriginalPrice
				}).ToList();

				return View(journeys);
			}
			else 
			{
				return RedirectToAction("Index");
			}
			
		}
	}
}
