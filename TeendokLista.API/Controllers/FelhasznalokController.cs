using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeendokLista.API.Models;

namespace TeendokLista.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Adminisztrátor")]
    public class FelhasznalokController : ControllerBase
    {
        private readonly TeendokContext _context;

        public FelhasznalokController(TeendokContext context)
        {
            _context = context;
        }

        // GET: api/Felhasznalok
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Felhasznalo>>> Getfelhasznalok()
        {
            return await _context.felhasznalok.ToListAsync();
        }

        // GET: api/Felhasznalok/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Felhasznalo>> GetFelhasznalo(int id)
        {
            var felhasznalo = await _context.felhasznalok.FindAsync(id);

            if (felhasznalo == null)
            {
                return NotFound();
            }

            return felhasznalo;
        }

        // PUT: api/Felhasznalok/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFelhasznalo(int id, Felhasznalo felhasznalo)
        {
            if (id != felhasznalo.Id)
            {
                return BadRequest();
            }

            _context.Entry(felhasznalo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FelhasznaloExists(id))
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

        // POST: api/Felhasznalok
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Felhasznalo>> PostFelhasznalo(Felhasznalo felhasznalo)
        {
            _context.felhasznalok.Add(felhasznalo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFelhasznalo", new { id = felhasznalo.Id }, felhasznalo);
        }

        // DELETE: api/Felhasznalok/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFelhasznalo(int id)
        {
            var felhasznalo = await _context.felhasznalok.FindAsync(id);
            if (felhasznalo == null)
            {
                return NotFound();
            }

            _context.felhasznalok.Remove(felhasznalo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FelhasznaloExists(int id)
        {
            return _context.felhasznalok.Any(e => e.Id == id);
        }
    }
}
