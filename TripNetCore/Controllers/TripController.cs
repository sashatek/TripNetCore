using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripNetCore.DAL.DbModels;
using TripNetCore.Utils;
using TripNetCore.Models;
using TripNetCore.DAL;

namespace TripCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class TripController : ControllerBase
    {
        private readonly DevCodeContext _db;

        public TripController(DevCodeContext context)
        {
            _db = context;
        }
        // GET: api/TripApi
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var dao = new TripDao(_db);
            var models = await dao.getTripsAsync();
            return Ok(models);
        }

        // GET: api/TripApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrip([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TripModel model;
            try
            {
                var dao = new TripDao(_db);
                model = await  dao.getTripAsync(id);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = ErrorUtils.dbErrorMessage($"Can't get Trip with id={id}", e) });
            }

            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        // PUT: api/TripApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrip([FromRoute] int id, [FromBody] TripModel tripModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tripModel.tripId)
            {
                return BadRequest();
            }
            if (!TripExists(id))
            {
                return NotFound();
            }

            try
            {
                var dao = new TripDao(_db);
                tripModel = await dao.saveTripAsync(tripModel);
            }
            catch (Exception e)
            {
                if (!TripExists(id))
                {
                    return NotFound();
                }
                return BadRequest(new { message = ErrorUtils.dbErrorMessage($"Can't save Trip with id={id}", e) });
            }

            return NoContent(); // Or Ok(tripModel);
        }

        // POST: api/TripApi
        [Route("PostTrip")]
        [HttpPost]
        public async Task<IActionResult> PostTrip([FromBody] TripModel tripModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var dao = new TripDao(_db);
                //tripModel.transTypeId = 100;
                tripModel = await dao.addTripAsync(tripModel);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = ErrorUtils.dbErrorMessage($"Can't insert (add) Trip", e) });
            }

            return CreatedAtAction("GetTrip", new { id = tripModel.tripId }, tripModel);
        }

        // DELETE: api/Test/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrip([FromRoute] int id)
        {
            try
            {
                var dao = new TripDao(_db);
                if (await dao.deleteTripAsync(id) == -1)
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = ErrorUtils.dbErrorMessage($"Can't delete Trip", e) });
            }

            return Ok();
        }

        private bool TripExists(int id)
        {
            return _db.Trip.Any(e => e.TripId == id);
        }
    }
}