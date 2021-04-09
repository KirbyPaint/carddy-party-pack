using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarddyPartyBackEnd.Models;
// using System.Web.Http.Cors;

namespace CarddyPartyBackEnd.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  
  public class CardsController : ControllerBase
  {
    private readonly CarddyPartyBackEndContext _db;

    public CardsController(CarddyPartyBackEndContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Card>>> Get()
    {
      var query = _db.Cards.AsQueryable();
      return await query.ToListAsync();
    }
    [HttpGet("recent")]
    public async Task<ActionResult<IEnumerable<Card>>> GetRecent()
    {
      int max = _db.Cards.Count();
      var query = _db.Cards.AsQueryable();
      query = query.Where(e => e.CardId >= max - 9);
      return await query.ToListAsync();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Card>> GetCard(int id)
    {
        var card = await _db.Cards.FindAsync(id);
        if (card == null)
        {
            return NotFound();
        }
        return card;
    }
    [HttpGet("random")]
    public async Task<ActionResult<Card>> GetRandomCard()
    {
      Random rand = new Random();
      int id = rand.Next(1, _db.Cards.Count());
      var card = await _db.Cards.FindAsync(id);
      if (card == null)
      {
        return NotFound();
      }
      return card;
    }
    [HttpPost]
    public async Task<ActionResult<Card>> Post(Card card)
    {
      _db.Cards.Add(card);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetCard), new { id = card.CardId }, card);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCard(int id)
    {
      var card = await _db.Cards.FindAsync(id);
      if (card  == null)
      {
        return NotFound();
      }
      _db.Cards.Remove(card);
      await _db.SaveChangesAsync();
      return NoContent();
    }
  }
}