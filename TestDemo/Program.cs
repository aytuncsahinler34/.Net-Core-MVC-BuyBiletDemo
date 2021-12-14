using BuyBiletDemo.Core.Enums;
using BuyBiletDemo.Core.Helpers;
using BuyBiletDemo.Core.Models.Requests;
using BuyBiletDemo.Core.Models.Responses;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TestDemo
{
	class Program
	{
		static async Task Main(string[] args) {
			string baseUrl = "https://v2-api.obilet.com/api/";
			SessionRequest sessionRequest = new SessionRequest {
				Type = 7,
				Connection = new Connection() {
					IpAddress = "165.114.41.21",
					Port = "5117"
				},
				Browser = new Browser() {
                    Name ="Chrome",
					Version = "47.0.0.12"
				},
				Application = new Application() {
					EquipmentId = "distribusion",
					Version = "1.0.0.0"
				}
			};


			//appsettings.jsona alıncak veriler


			var data = await HttpHelper.HttpRequestAsync<SessionResponse>(baseUrl, "client/getsession", HttpMethodEnum.POST, sessionRequest, null, new AuthenticationHeaderValue("Basic", "JEcYcEMyantZV095WVc3G2JtVjNZbWx1"));


			BusLocationsRequest busLocationsRequest = new BusLocationsRequest {
				DataRequestForLocation = null,
				DeviceSessionLocation = new DeviceSessionLocation() {
					SessionId = data != null && data.Data != null ? data.Data.SessionId : string.Empty,
					DeviceId = data != null && data.Data != null ? data.Data.DeviceId : string.Empty,
				},
				Date = DateTime.Now
			};

			var data1 = await HttpHelper.HttpRequestAsync<BusLocationsResponse>(baseUrl, "location/getbuslocations", HttpMethodEnum.POST, busLocationsRequest, null, new AuthenticationHeaderValue("Basic", "JEcYcEMyantZV095WVc3G2JtVjNZbWx1"));

			BusJourneyRequest busJourneyRequest = new BusJourneyRequest {
				DataRequestForJourney = new DataRequestForJourney() { 
				  OriginId = 349,
				  DestinationId = 356,
				  DepartureDate = "2021-12-15"  //tarih ayarlanması lazım
				},
				DeviceSessionJourney = new DeviceSessionJourney() {
					SessionId = data != null && data.Data != null ? data.Data.SessionId : string.Empty,
					DeviceId = data != null && data.Data != null ? data.Data.DeviceId : string.Empty,
				},
				Date = DateTime.Now
			};

			var data2 = await HttpHelper.HttpRequestAsync<BusJourneyResponse>(baseUrl, "journey/getbusjourneys", HttpMethodEnum.POST, busJourneyRequest, null, new AuthenticationHeaderValue("Basic", "JEcYcEMyantZV095WVc3G2JtVjNZbWx1"));


		}
	}
}
