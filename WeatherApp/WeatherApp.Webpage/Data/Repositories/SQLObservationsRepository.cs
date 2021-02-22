using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherApp.WebSite.Models
{
    public class SQLObservationsRepository : IAsyncObservationRepository
    {
        private readonly ObservationsContext _context;

        public SQLObservationsRepository(ObservationsContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Observation observation)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Observation>> ReadAsync()
        {
            return _context.Observations;
        }

        public async Task UpdateAsync(long observationId)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(long observationId)
        {
            throw new NotImplementedException();
        }
    }
}
