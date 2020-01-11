///<author>Francisco José Ferrer Rodríguez<author>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Tienda.Models;

namespace API_Tienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly MySQLDbContext _context;

        public ArticulosController(MySQLDbContext context)
        {
            _context = context;
        }

        // GET: api/Articulos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Articulo>>> GetArticulo()
        {
            try
            {
                return await _context.Articulo.ToListAsync();
            }
            catch(Exception e)
            {
                return null;
            }
        }

        // GET: api/Articulos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Articulo>> GetArticulo(string id)
        {
            var articulo = await _context.Articulo.FindAsync(id);

            if (articulo == null)
            {
                return NotFound();
            }

            return articulo;
        }

        // PUT: api/Articulos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticulo(string id, Articulo articulo)
        {
            if (id != articulo.ArticuloID)
            {
                return BadRequest();
            }

            _context.Entry(articulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticuloExists(id))
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

        // POST: api/Articulos
        [HttpPost]
        public async Task<ActionResult<Articulo>> PostArticulo(Articulo articulo)
        {
            _context.Articulo.Add(articulo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticulo", new { id = articulo.ArticuloID }, articulo);
        }

        // DELETE: api/Articulos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Articulo>> DeleteArticulo(string id)
        {
            var articulo = await _context.Articulo.FindAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }

            _context.Articulo.Remove(articulo);
            await _context.SaveChangesAsync();

            return articulo;
        }

        private bool ArticuloExists(string id)
        {
            return _context.Articulo.Any(e => e.ArticuloID == id);
        }
    }
}
