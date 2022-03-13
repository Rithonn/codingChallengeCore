#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BreweryAPI.Models;

namespace BreweryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreweriesController : ControllerBase
    {
        private readonly BreweryDBContext _context;

        public BreweriesController(BreweryDBContext context)
        {
            _context = context;
        }

        // GET: api/Breweries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brewery>>> GetBreweries([FromQuery(Name = "by_city")] string by_city, [FromQuery(Name = "by_state")] string by_state)
        {
            if(by_state != null && by_city != null)
            {
                var queryByCityAndState = from breweries in _context.Breweries
                    where breweries.State == by_state && breweries.City == by_city
                    select breweries;

                return await queryByCityAndState.ToListAsync();
            }
            return await _context.Breweries.ToListAsync();
        }
        
        // GET: api/Breweries?:city&&town
        //[HttpGet("{by_city?}")]
        //public async Task<ActionResult<IEnumerable<Brewery>>> GetBreweriesByCityAndState()
        //{
           // var queryByCityAndState = from breweries in _context.Breweries
                                     // where breweries.State == by_state && breweries.City == by_city
                                     // select breweries;

          // return await queryByCityAndState.ToListAsync();
        //}

        // GET: api/Breweries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Brewery>> GetBrewery(int id)
        {
            var brewery = await _context.Breweries.FindAsync(id);

            if (brewery == null)
            {
                return NotFound();
            }

            return brewery;
        }

        // PUT: api/Breweries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrewery(int id, Brewery brewery)
        {
            if (id != brewery.BreweryId)
            {
                return BadRequest();
            }

            _context.Entry(brewery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BreweryExists(id))
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

        // POST: api/Breweries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Brewery>> PostBrewery(Brewery brewery)
        {
            _context.Breweries.Add(brewery);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBrewery", new { id = brewery.BreweryId }, brewery);
        }

        // DELETE: api/Breweries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrewery(int id)
        {
            var brewery = await _context.Breweries.FindAsync(id);
            if (brewery == null)
            {
                return NotFound();
            }

            _context.Breweries.Remove(brewery);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BreweryExists(int id)
        {
            return _context.Breweries.Any(e => e.BreweryId == id);
        }
    }
}
