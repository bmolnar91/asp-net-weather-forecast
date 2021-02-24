using System;
using System.Collections.Generic;
using System.Linq;

namespace WeatherApp.WebSite.Models
{
    public class InMemoryObservationRepository : IObservationRepository
    {
        readonly IList<Observation> _observations = new List<Observation>() {
            new Observation
            {
                Id = 1,
                City = "Budapest",
                UserName = "User",
                Description = "It is very hot and sunny here",
                Timestamp = new DateTime(2020, 11, 14, 9, 28, 0),
            },
            new Observation
            {
                Id = 2,
                City = "Budapest",
                UserName = "Jane",
                Description = "Freezing cold",
                Timestamp = new DateTime(2020, 10, 14, 9, 28, 0),
            },
            new Observation
            {
                Id = 3,
                City = "Madrid",
                UserName = "Pablo",
                Description = "Beach time!",
                Timestamp = new DateTime(2020, 6, 14, 9, 28, 0),
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

        public void DeleteObservation(long observationId)
        {
            throw new NotImplementedException();
        }

        public void UpdateObservation(long observationId)
        {
            throw new NotImplementedException();
        }
    }
}
