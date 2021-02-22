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
                ID = 1,
                City = "Budapest",
                TimeStamp = new DateTime(2020, 11, 14, 9, 28, 0),
                UserName = "User",
                Description = "It is very hot and sunny here"
            },
            new Observation
            {
                ID = 2,
                City = "Budapest",
                TimeStamp = new DateTime(2020, 10, 14, 9, 28, 0),
                UserName = "Jane",
                Description = "Freezing cold"
            },
            new Observation
            {
                ID = 3,
                City = "Madrid",
                TimeStamp = new DateTime(2020, 6, 14, 9, 28, 0),
                UserName = "Pablo",
                Description = "Beach time!"
            }
        };

        public void AddObservation(Observation observation)
        {
            long newID = _observations.Select(observation => observation.ID).Max() + 1;
            observation.ID = newID;

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
