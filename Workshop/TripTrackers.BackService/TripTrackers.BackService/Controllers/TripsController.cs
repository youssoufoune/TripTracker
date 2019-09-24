using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripTrackers.BackService.Models;

namespace TripTrackers.BackService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        public TripsController(Models.Repository repository)
        {
            _repository = repository; // putting repository in the private field so we can interact with it
        }
        private Models.Repository _repository;
        // GET api/values
        [HttpGet]
        public IEnumerable<Trip> Get()
        {
            return _repository.GetAllTrips();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Trip Get(int id)
        {
            return _repository.GetTrip(id); 
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Trip trip)
        {
            _repository.AddTrip(trip);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Trip trip)
        {
            _repository.Update(trip);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.RemoveTrip(id);
        }
    }
}
