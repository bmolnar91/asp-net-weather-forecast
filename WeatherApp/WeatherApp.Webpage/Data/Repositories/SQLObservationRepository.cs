using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherApp.WebSite.Models
{
    public class SQLObservationRepository : IAsyncObservationRepository
    {
        private readonly ObservationsContext _context;

        public SQLObservationRepository(ObservationsContext context)
        {
            _context = context;
        }

        public async Task AddObservationAsync(Observation observation)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Observation>> GetObservationsAsync()
        {
            return _context.Observations;
        }

        public async Task UpdateObservationAsync(long observationId)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteObservationAsync(long observationId)
        {
            throw new NotImplementedException();
        }
    }
}
