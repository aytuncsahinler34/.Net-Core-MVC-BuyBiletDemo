using BuyBiletDemo.Core.Models.Args;
using BuyBiletDemo.Core.Models.Requests;
using BuyBiletDemo.Core.Models.Responses;
using System.Threading.Tasks;

namespace BuyBiletDemo.Core.Interfaces
{
	public interface IOBiletIntegrationService
	{
		Task<BusLocationsResponse> GetBusLocationAsync(SessionRequest _appIdentitySettings);
		Task<BusJourneyResponse> GetBusJourneyAsync(SessionRequest _appIdentitySettings, FilterJourneyArgs filterJourneyArgs);
	}
}
