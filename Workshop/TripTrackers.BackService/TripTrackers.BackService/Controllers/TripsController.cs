using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripTrackers.BackService.Data;
using TripTrackers.BackService.Models;

namespace TripTrackers.BackService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        TripContext _context; // instanciated per every new request
        public TripsController(TripContext context) // asp.net will inject TripContext object into _context;
        {
            _context = context; // putting repository in the private field so we can interact with it
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetAsync() // Method that returns all the trips from Db as an asynchronous operation
        {
            var trips = await _context.Trips.AsNoTracking().ToListAsync(); // turn off tracking and return a list of trips 
            return Ok(trips); // ok response
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Trip Get(int id) //Method that returns all the trips from Db as an asynchronous operation
        {
            return _context.Trips.Find(id); // return a trip with id
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Trip trip)
        {
            if (!ModelState.IsValid) // if state of model is NOT valid
            {
                return BadRequest(ModelState); // return bad request
            }
            _context.Trips.Add(trip); // if not add trip the database
            _context.SaveChanges(); // update database
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Trip trip)
        {
            if (!_context.Trips.Any(t => t.Id == id)) // tests if there is any trip with the id passed as parameter if not return not found
            {
                return NotFound();
            }

            if (!ModelState.IsValid) //if state of model is NOT valid return bad request
            {
                return BadRequest(ModelState);
            }

            _context.Trips.Update(trip); // if state valid and trip found, update with the modified trip
            await _context.SaveChangesAsync(); //waits for the update to finish

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var myTrip = _context.Trips.Find(id);
            if (myTrip == null)
            {
                return NotFound();
            }
            _context.Trips.Remove(myTrip);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
