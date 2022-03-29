using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Models;
using System.Linq;

namespace TravelAgency.Controllers
{
  [Route("api/Travels/Reviews")]
  [ApiController]
  public class ReviewsController : ControllerBase
  {
    private readonly TravelAgencyContext _db;

    public ReviewsController(TravelAgencyContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Review>>> Get(string text, int rating, string name, string city, string country)
    {
      var query = _db.Reviews   // You need this to be able to display json data for that field
        .Include(a => a.User)
        .Include(b => b.Destination)
        .AsQueryable();

      if (text != null)
      {
        query = query.Where(entry => entry.Text == text);
      }
      if (rating != 0)
      {
        query = query.Where(entry => entry.Rating == rating);
      }
      if (name != null)
      {
        query = query.Where(a => a.User.Name == name);
      }
      if (city != null)
      {
        query = query.Where(a => a.Destination.City == city);
      }
      if (country != null)
      {
        query = query.Where(a => a.Destination.Country == country);
      }
      return await query.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Review>> Post(Review review)
    {
      _db.Reviews.Add(review);
      await _db.SaveChangesAsync();

      return CreatedAtAction("Post", new { id = review.ReviewId }, review);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Review>> GetDestination(int id)
    {
      var review = await _db.Reviews.FindAsync(id);

      if (review == null)
      {
        return NotFound();
      }

      return review;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Review review)
    {
      if (id != review.ReviewId)
      {
        return BadRequest();
      }

      _db.Entry(review).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ReviewExists(id))
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
    private bool ReviewExists(int id)
    {
      return _db.Reviews.Any(e => e.ReviewId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReview(int id)
    {
      var review = await _db.Reviews.FindAsync(id);
      if (review == null)
      {
        return NotFound();
      }

      _db.Reviews.Remove(review);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}