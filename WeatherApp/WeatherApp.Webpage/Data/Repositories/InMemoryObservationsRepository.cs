using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.WebSite.Models
{
    public class InMemoryObservationsRepository : IObservationRepository
    {
        readonly IList<Observation> _observations = new List<Observation>() {
            new Observation
            {
                Id = 1,
                City = "Budapest",
                Timestamp = new DateTime(2020, 11, 14, 9, 28, 0),
                UserName = "User",
                Description = "It is very hot and sunny here"
            },
            new Observation
            {
                Id = 2,
                City = "Budapest",
                Timestamp = new DateTime(2020, 10, 14, 9, 28, 0),
                UserName = "Jane",
                Description = "Freezing cold"
            },
            new Observation
            {
                Id = 3,
                City = "Madrid",
                Timestamp = new DateTime(2020, 6, 14, 9, 28, 0),
                UserName = "Pablo",
                Description = "Beach time!"
            }
        };

        public void AddObservation(Observation observation)
        {
            long newID = _observations.Select(observation => observation.Id).Max() + 1;
            observation.Id = newID;

           _observations.Add(observation);
        }

        public IEnumerable<Observation> GetObservations()
        {
            return _observations;
        }

        // TODO
        public void DeleteObservation(long observationId)
        {
            throw new NotImplementedException();
        }

        // TODO
        public void UpdateObservation(long observationId)
        {
            throw new NotImplementedException();
        }
    }
}
