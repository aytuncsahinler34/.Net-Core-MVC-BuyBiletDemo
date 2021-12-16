using BuyBiletDemo.Core.Models.Responses;
using System.Threading.Tasks;

namespace BuyBiletDemo.Core.Interfaces
{
	public interface IOBiletIntegrationService
	{
		Task<BusLocationsResponse> GetBusLocationAsync();
		Task<BusJourneyResponse> GetBusJourneyAsync();
	}
}
