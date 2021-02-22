using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherApp.WebSite.Models
{
    public interface IAsyncObservationRepository
    {
        Task CreateAsync(Observation observation);
        Task<IEnumerable<Observation>> ReadAsync();
        Task UpdateAsync(long observationId);
        Task DeleteAsync(long observationId);
    }
}
