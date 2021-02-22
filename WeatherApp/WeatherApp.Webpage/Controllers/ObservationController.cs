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

        public Observation Observation { get; private set; }

        [HttpGet("observations")]
        public async Task<IEnumerable<Observation>> GetAllObservations()
        {
            var observations = await _observationRepository.ReadAsync();
            return observations;
        }

        [HttpGet("{city}")]
        public async Task<IEnumerable<Observation>> GetObservationsByCity(string city)
        {
            var observations = await _observationRepository.ReadAsync();
            var observationsByCity =
                from observation in observations
                where observation.City.Equals(city)
                select observation;

            return observationsByCity.ToArray();
        }

        [HttpPost("{city}")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task PostAsync([FromForm] IFormCollection formCollection, string city)
        {
            string userName = formCollection[nameof(userName)];
            string description = formCollection[nameof(description)];

            Observation obs = new Observation()
            {
                TimeStamp =   DateTime.Now,
                City =        city,
                UserName =    userName,
                Description = description,
            };

            await _observationRepository.CreateAsync(obs);
        }

        // TODO post, put, delete http requests
    }
}
