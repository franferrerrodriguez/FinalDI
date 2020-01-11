///<author>Francisco José Ferrer Rodríguez<author>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Tienda.Models;

namespace ApiTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemoriasController : ControllerBase
    {
        private readonly MySQLDbContext _context;

        public MemoriasController(MySQLDbContext context)
        {
            _context = context;
        }

        // GET: api/Memorias
        [HttpGet]
        public IEnumerable<Memoria> GetMemoria()
        {
            return _context.Memoria;
        }

        // GET: api/Memorias/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMemoria([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var memoria = await _context.Memoria.FindAsync(id);

            if (memoria == null)
            {
                return NotFound();
            }

            return Ok(memoria);
        }

        // PUT: api/Memorias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMemoria([FromRoute] string id, [FromBody] Memoria memoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != memoria.MemoriaID)
            {
                return BadRequest();
            }

            _context.Entry(memoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemoriaExists(id))
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

        // POST: api/Memorias
        [HttpPost]
        public async Task<IActionResult> PostMemoria([FromBody] Memoria memoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Memoria.Add(memoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMemoria", new { id = memoria.MemoriaID }, memoria);
        }

        // DELETE: api/Memorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMemoria([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var memoria = await _context.Memoria.FindAsync(id);
            if (memoria == null)
            {
                return NotFound();
            }

            _context.Memoria.Remove(memoria);
            await _context.SaveChangesAsync();

            return Ok(memoria);
        }

        private bool MemoriaExists(string id)
        {
            return _context.Memoria.Any(e => e.MemoriaID == id);
        }
    }
}