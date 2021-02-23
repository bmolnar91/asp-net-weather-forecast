using System.Collections.Generic;

namespace WeatherApp.WebSite.Models
{
    public interface IObservationRepository
    {
        void AddObservation(Observation observation);
        IEnumerable<Observation> GetObservations();
        void UpdateObservation(long observationId);
        void DeleteObservation(long observationId);
    }
}
