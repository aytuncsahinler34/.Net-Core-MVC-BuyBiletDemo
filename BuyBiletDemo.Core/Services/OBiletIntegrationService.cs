using BuyBiletDemo.Core.Enums;
using BuyBiletDemo.Core.Helpers;
using BuyBiletDemo.Core.Interfaces;
using BuyBiletDemo.Core.Models.Requests;
using BuyBiletDemo.Core.Models.Responses;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BuyBiletDemo.Core.Services
{
	public class OBiletIntegrationService : IOBiletIntegrationService
	{
		private readonly string  baseUrl = "https://v2-api.obilet.com/api/";
		private readonly AuthenticationHeaderValue token = new AuthenticationHeaderValue("Basic", "JEcYcEMyantZV095WVc3G2JtVjNZbWx1");
		private async  Task<SessionResponse> GetSessionAsync() 
		{
			SessionRequest sessionRequest = new SessionRequest {
				Type = 7,
				Connection = new Connection() {
					IpAddress = "165.114.41.21",
					Port = "5117"
				},
				Browser = new Browser() {
					Name = "Chrome",
					Version = "47.0.0.12"
				},
				Application = new Application() {
					EquipmentId = "distribusion",
					Version = "1.0.0.0"
				}
			};

			return await HttpHelper.HttpRequest<SessionResponse>(baseUrl, "client/getsession", HttpMethodEnum.POST, sessionRequest, null, token);

		}

		public async Task<BusLocationsResponse> GetBusLocationAsync() 
		{

			var sessionData = await GetSessionAsync();

			BusLocationsRequest busLocationsRequest = new BusLocationsRequest {
				DataRequestForLocation = null,
				DeviceSessionLocation = new DeviceSessionLocation() {
					SessionId = sessionData != null && sessionData.Data != null ? sessionData.Data.SessionId : string.Empty,
					DeviceId = sessionData != null && sessionData.Data != null ? sessionData.Data.DeviceId : string.Empty,
				},
				Date = DateTime.Now
			};

			return await  HttpHelper.HttpRequest<BusLocationsResponse>(baseUrl, "location/getbuslocations", HttpMethodEnum.POST, busLocationsRequest, null, token);

		}

		public async Task<BusJourneyResponse> GetBusJourneyAsync() {

			var sessionData = await GetSessionAsync();

			BusJourneyRequest busJourneyRequest = new BusJourneyRequest {
				DataRequestForJourney = new DataRequestForJourney() {
					OriginId = 349,
					DestinationId = 356,
					DepartureDate = "2021-12-16"
				},
				DeviceSessionJourney = new DeviceSessionJourney() {
					SessionId = sessionData != null && sessionData.Data != null ? sessionData.Data.SessionId : string.Empty,
					DeviceId = sessionData != null && sessionData.Data != null ? sessionData.Data.DeviceId : string.Empty,
				},
				Date = DateTime.Now
			};

			return await HttpHelper.HttpRequest<BusJourneyResponse>(baseUrl, "journey/getbusjourneys", HttpMethodEnum.POST, busJourneyRequest, null, token);


		}
	}
}
