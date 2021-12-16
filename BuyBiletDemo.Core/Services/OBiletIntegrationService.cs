using BuyBiletDemo.Core.Enums;
using BuyBiletDemo.Core.Helpers;
using BuyBiletDemo.Core.Interfaces;
using BuyBiletDemo.Core.Models.Args;
using BuyBiletDemo.Core.Models.Requests;
using BuyBiletDemo.Core.Models.Responses;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BuyBiletDemo.Core.Services
{
	public class OBiletIntegrationService : IOBiletIntegrationService
	{
		private async  Task<SessionResponse> GetSessionAsync(SessionRequest _appIdentitySettings) 
		{
			SessionRequest sessionRequest = new SessionRequest {
				Type = 7,
				Connection = new Connection() {
					IpAddress = _appIdentitySettings.Connection.IpAddress,
					Port = _appIdentitySettings.Connection.Port
				},
				Browser = new Browser() {
					Name = _appIdentitySettings.Browser.Name,
					Version = _appIdentitySettings.Browser.Version
				},
				Application = new Application() {
					EquipmentId = _appIdentitySettings.Application.EquipmentId,
					Version = _appIdentitySettings.Application.Version
				}
			};

			return await HttpHelper.HttpRequest<SessionResponse>(_appIdentitySettings.BaseUrl, "client/getsession", HttpMethodEnum.POST, sessionRequest, null, new AuthenticationHeaderValue(_appIdentitySettings.SchemaName, _appIdentitySettings.TokenValue));

		}

		public async Task<BusLocationsResponse> GetBusLocationAsync(SessionRequest _appIdentitySettings) 
		{

			var sessionData = await GetSessionAsync(_appIdentitySettings);

			BusLocationsRequest busLocationsRequest = new BusLocationsRequest {
				DataRequestForLocation = null,
				DeviceSessionLocation = new DeviceSessionLocation() {
					SessionId = sessionData != null && sessionData.Data != null ? sessionData.Data.SessionId : string.Empty,
					DeviceId = sessionData != null && sessionData.Data != null ? sessionData.Data.DeviceId : string.Empty,
				},
				Date = DateTime.Now
			};

			return await  HttpHelper.HttpRequest<BusLocationsResponse>(_appIdentitySettings.BaseUrl, "location/getbuslocations", HttpMethodEnum.POST, busLocationsRequest, null, new AuthenticationHeaderValue(_appIdentitySettings.SchemaName, _appIdentitySettings.TokenValue));

		}

		public async Task<BusJourneyResponse> GetBusJourneyAsync(SessionRequest _appIdentitySettings, FilterJourneyArgs filterJourneyArgs) {

			var sessionData = await GetSessionAsync(_appIdentitySettings);

			BusJourneyRequest busJourneyRequest = new BusJourneyRequest {
				DataRequestForJourney = new DataRequestForJourney() {
					OriginId = filterJourneyArgs.FromLocationId,
					DestinationId = filterJourneyArgs.ToLocationId,
					DepartureDate = filterJourneyArgs.DateTime.ToString("yyyy-MM-dd")
				},
				DeviceSessionJourney = new DeviceSessionJourney() {
					SessionId = sessionData != null && sessionData.Data != null ? sessionData.Data.SessionId : string.Empty,
					DeviceId = sessionData != null && sessionData.Data != null ? sessionData.Data.DeviceId : string.Empty,
				},
				Date = DateTime.Now
			};

			return await HttpHelper.HttpRequest<BusJourneyResponse>(_appIdentitySettings.BaseUrl, "journey/getbusjourneys", HttpMethodEnum.POST, busJourneyRequest, null, new AuthenticationHeaderValue( _appIdentitySettings.SchemaName, _appIdentitySettings.TokenValue));


		}
	}
}
