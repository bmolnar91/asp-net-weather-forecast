using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.WebSite.Models;

namespace WeatherApp.WebSite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObservationController : ControllerBase
    {
        readonly IAsyncObservationRepository _observationRepository;

        public ObservationController(IAsyncObservationRepository observationRepository)
        {
            _observationRepository = observationRepository;
        }

        [HttpGet("observations")]
        public async Task<IEnumerable<Observation>> GetAllObservationsAsync()
        {
            return await _observationRepository.GetObservationsAsync();
        }

        [HttpGet("{city}")]
        public async Task<IEnumerable<Observation>> GetObservationsByCityAsync(string city)
        {
            var observations = await _observationRepository.GetObservationsAsync();
            var observationsByCity =
                from observation in observations
                where observation.City.Equals(city)
                select observation;

            return observationsByCity.ToArray();
        }

        [HttpPost("{city}")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task AddObservationAsync([FromForm] IFormCollection formCollection, string city)
        {
            string userName = formCollection[nameof(userName)];
            string description = formCollection[nameof(description)];

            Observation obs = new Observation()
            {
                City =        city,
                UserName =    userName,
                Description = description,
                Timestamp =   DateTime.Now,
            };

            await _observationRepository.AddObservationAsync(obs);
        }
    }
}
