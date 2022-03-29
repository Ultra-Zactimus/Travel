using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Models;
using System.Linq;

namespace TravelAgency.Controllers
{
  [Route("api/Travels/Users")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly TravelAgencyContext _db;

    public UsersController(TravelAgencyContext db)
    {
      _db = db;
    }

        [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> Get(string name)
    {
      var query = _db.Users       // You need this to be able to display json data for that field
        .Include(a => a.Reviews)
        .AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }
    
      return await query.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<User>> Post(User user)
    {
      _db.Users.Add(user);
      await _db.SaveChangesAsync();

      return CreatedAtAction("Post", new { id = user.UserId }, user);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetReview(int id)
    {
      var user = await _db.Users.FindAsync(id);

      if (user == null)
      {
        return NotFound();
      }

      return user;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, User user)
    {
      if (id != user.UserId)
      {
        return BadRequest();
      }

      _db.Entry(user).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!UserExists(id))
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
    private bool UserExists(int id)
    {
      return _db.Users.Any(e => e.UserId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
      var user = await _db.Users.FindAsync(id);
      if (user == null)
      {
        return NotFound();
      }

      _db.Users.Remove(user);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}