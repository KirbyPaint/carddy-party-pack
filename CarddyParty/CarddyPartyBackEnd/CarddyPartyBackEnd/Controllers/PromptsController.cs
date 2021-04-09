using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarddyPartyBackEnd.Models;

namespace CarddyPartyBackEnd.Controllers
{
  [Route("api/[controller]")]
  [ApiController]

  public class PromptsController : ControllerBase
  {
    private readonly CarddyPartyBackEndContext _db;

    public PromptsController(CarddyPartyBackEndContext db)
    {
      _db = db;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Prompt>>> Get(string theme)
    {
      var query = _db.Prompts.AsQueryable();
      if(theme != null)
      {
        query = query.Where(entry => entry.Theme == theme);
      }
      return await query.ToListAsync();
    }
    [HttpGet("random")]
    public async Task<ActionResult<Prompt>> GetRandomPrompt()
    {
      Random rand = new Random();
      int id = rand.Next(1, _db.Prompts.Count());
      var prompt = await _db.Prompts.FindAsync(id);
      if (prompt == null)
      {
        return NotFound();
      }
      return prompt;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Prompt>> GetPrompt(int id)
    {
      var prompt = await _db.Prompts.FindAsync(id);
      if(prompt == null)
      {
        return NotFound();
      }
      return prompt;
    }

    [HttpPost]
    public async Task<ActionResult<Prompt>> Post([FromBody] Prompt prompt)
    {
      _db.Prompts.Add(prompt);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetPrompt), new { id = prompt.PromptId }, prompt);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Prompt prompt)
    {
      if (id != prompt.PromptId)
      {
        return BadRequest();
      }
      _db.Entry(prompt).State = EntityState.Modified;
      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!PromptExists(id))
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

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePrompt(int id)
    {
      var prompt = await _db.Prompts.FindAsync(id);
      if(prompt == null)
      {
        return NotFound();
      }
      _db.Prompts.Remove(prompt);
      await _db.SaveChangesAsync();
      return NoContent();
    }

    private bool PromptExists(int id)
    {
      return _db.Prompts.Any(prompt => prompt.PromptId == id);
    }
  }
}