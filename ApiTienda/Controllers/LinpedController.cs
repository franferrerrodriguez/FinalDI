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
    public class LinpedsController : ControllerBase
    {
        private readonly MySQLDbContext _context;

        public LinpedsController(MySQLDbContext context)
        {
            _context = context;
        }

        // GET: api/Linpeds
        [HttpGet]
        public IEnumerable<Linped> GetLinped()
        {
            return _context.Linped;
        }

        // GET: api/Linpeds/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLinped([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var linped = await _context.Linped.Where(x => x.PedidoID == id).ToListAsync();

            if (linped == null)
            {
                return NotFound();
            }

            return Ok(linped);
        }

        // GET: api/Linpeds/5/1
        [HttpGet("{id:int}/{id_linea:int}")]
        public async Task<IActionResult> GetLinped([FromRoute] long id, int id_linea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            object[] param = new object[] { id, id_linea };
            var linped = await _context.Linped.FindAsync(param);

            if (linped == null)
            {
                return NotFound();
            }

            return Ok(linped);
        }

        // PUT: api/Linpeds/5/1
        [HttpPut("{id:int}/{id_linea:int}")]
        public async Task<IActionResult> PutLinped([FromRoute] long id, [FromBody] Linped linped)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != linped.PedidoID)
            {
                return BadRequest();
            }

            _context.Entry(linped).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinpedExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(linped);
            //return NoContent();
        }

        // POST: api/Linpeds
        [HttpPost]
        public async Task<IActionResult> PostLinped([FromBody] Linped linped)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Linped.Add(linped);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLinped", new { id = linped.PedidoID, id_linea = linped.Linea }, linped);
        }


        // DELETE: api/Linpeds/5/1
        [HttpDelete("{id:int}/{id_linea:int}")]
        public async Task<IActionResult> DeleteLinped([FromRoute] long id, int id_linea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            object[] param = new object[] { id, id_linea };
            var linped = await _context.Linped.FindAsync(param);

            if (linped == null)
            {
                return NotFound();
            }

            _context.Linped.Remove(linped);
            await _context.SaveChangesAsync();

            return Ok(linped);
        }

        private bool LinpedExists(long id)
        {
            return _context.Linped.Any(e => e.PedidoID == id);
        }
    }
}