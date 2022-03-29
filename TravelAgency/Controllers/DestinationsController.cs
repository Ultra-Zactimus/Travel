using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Models;
using System.Linq;

namespace TravelAgency.Controllers
{
  [Route("api/Travels/Destinations")]
  [ApiController]
  public class DestinationsController : ControllerBase
  {
    private readonly TravelAgencyContext _db;

    public DestinationsController(TravelAgencyContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Destination>>> Get(string country, string city)
    {
      var query = _db.Destinations    // You need this to be able to display json data for that field
        .Include(a => a.Reviews)
        .AsQueryable();

      if (country != null)
      {
        query = query.Where(entry => entry.Country == country);
      }

      if (city != null)
      {
        query = query.Where(entry => entry.City == city);
      }
      return await query.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Destination>> Post(Destination destination)
    {
      _db.Destinations.Add(destination);
      await _db.SaveChangesAsync();

      return CreatedAtAction("Post", new { id = destination.DestinationId }, destination);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Destination>> GetDestination(int id)
    {
      var destination = await _db.Destinations.FindAsync(id);

      if (destination == null)
      {
        return NotFound();
      }

      return destination;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Destination destination)
    {
      if (id != destination.DestinationId)
      {
        return BadRequest();
      }

      _db.Entry(destination).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!DestinationExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }
    private bool DestinationExists(int id)
    {
      return _db.Destinations.Any(e => e.DestinationId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDestination(int id)
    {
      var destination = await _db.Destinations.FindAsync(id);
      if (destination == null)
      {
        return NotFound();
      }

      _db.Destinations.Remove(destination);
      await _db.SaveChangesAsync();

      return NoContent();
    }

  }
    [ApiVersion("2.0")]
    [Route("api/Travels/Destinations")] ///api/values?api-version=2.0
    [ApiController]
    public class DestinationsV2Controller : ControllerBase
  {
    private readonly TravelAgencyContext _db;

    public DestinationsV2Controller(TravelAgencyContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Destination>>> Get(string country, string city)
    {
      var query = _db.Destinations    // You need this to be able to display json data for that field
        .Include(a => a.Reviews)
        .AsQueryable();

      if (country != null)
      {
        query = query.Where(entry => entry.Country == country);
      }

      if (city != null)
      {
        query = query.Where(entry => entry.City == city);
      }
      return await query.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Destination>> Post(Destination destination)
    {
      _db.Destinations.Add(destination);
      await _db.SaveChangesAsync();

      return CreatedAtAction("Post", new { id = destination.DestinationId }, destination);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Destination>> GetDestination(int id)
    {
      var destination = await _db.Destinations.FindAsync(id);

      if (destination == null)
      {
        return NotFound();
      }

      return destination;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Destination destination)
    {
      if (id != destination.DestinationId)
      {
        return BadRequest();
      }

      _db.Entry(destination).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!DestinationExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }
    private bool DestinationExists(int id)
    {
      return _db.Destinations.Any(e => e.DestinationId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDestination(int id)
    {
      var destination = await _db.Destinations.FindAsync(id);
      if (destination == null)
      {
        return NotFound();
      }

      _db.Destinations.Remove(destination);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}