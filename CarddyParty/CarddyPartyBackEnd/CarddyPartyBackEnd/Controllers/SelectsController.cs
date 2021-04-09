using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarddyPartyBackEnd.Models;

namespace CarddyPartyBackEnd.Controllers
{
  [Route("api/[controller]")]
  [ApiController]

  public class SelectsController : ControllerBase
  {
    private readonly CarddyPartyBackEndContext _db;

    public SelectsController(CarddyPartyBackEndContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Select>>> Get()
    {
      var query = _db.Selects.AsQueryable();
      return await query.ToListAsync();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Select select)
    {
      if (id != select.SelectId)
      {
        return BadRequest();
      }
      _db.Entry(select).State = EntityState.Modified;
      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!SelectExists(id))
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
        private bool SelectExists(int id)
    {
      return _db.Selects.Any(prompt => prompt.SelectId == id);
    }
    [HttpPost]
    public async Task<ActionResult<Select>> Post(Select select)
    {
      _db.Selects.Add(select);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetS), new { id = select.SelectId }, select);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Select>> GetS(int id)
    {
        var select = await _db.Selects.FindAsync(id);
        if (select == null)
        {
            return NotFound();
        }
        return select;
    }
  }
}