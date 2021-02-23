using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherApp.WebSite.Models
{
    public interface IAsyncObservationRepository
    {
        Task AddObservationAsync(Observation observation);
        Task<IEnumerable<Observation>> GetObservationsAsync();
        Task UpdateObservationAsync(long observationId);
        Task DeleteObservationAsync(long observationId);
    }
}
