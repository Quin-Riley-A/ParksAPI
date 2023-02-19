using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ParkApi.Models;

namespace ParkApi.Controllers.V2
{
  [ApiController]
  [Route("api/v{version:apiVersion}/[controller]")]
  [ApiVersion("2.0")]
  public class ParksController : ControllerBase
  {
    private readonly ParksApiContext _db;
    public ParksController (ParksApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> Get(string parkName, string parkState, string municipality)
    {
      IQueryable<Park> query = _db.Parks.AsQueryable();

      if (parkName != null)
      {
        query = query.Where(entry => entry.ParkName == parkName);
      }

      if (parkState !=null)
      {
        query = query.Where(entry => entry.ParkState == parkState);
      }

      if (municipality !=null)
      {
        query = query.Where(entry => entry.Municipality == municipality);
      }

      return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark (int id)
    {
      Park park = await _db.Parks.FindAsync(id);

      if (park == null)
      {
        return NotFound();
      }

      return park;
    }

    [HttpPost]
    public async Task<ActionResult<Park>> Post (Park park)
    {
      _db.Parks.Add(park);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetPark), new {id = park.ParkId }, park);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Park park)
    {
      if (id != park.ParkId)
      {
        return BadRequest();
      }

      _db.Parks.Update(park);

      try 
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ParkExists(id))
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

    private bool ParkExists(int id)
    {
      return _db.Parks.Any(e => e.ParkId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePark(int id)
    {
      Park park = await _db.Parks.FindAsync(id);
      if (park == null)
      {
        return NotFound();
      }

      _db.Parks.Remove(park);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}