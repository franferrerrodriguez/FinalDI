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
    public class LocalidadesController : ControllerBase
    {
        private readonly MySQLDbContext _context;

        public LocalidadesController(MySQLDbContext context)
        {
            _context = context;
        }

        // GET: api/Localidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Localidad>>> GetLocalidad()
        {
            return await _context.Localidad.ToListAsync();
        }

        // GET: api/Localidades/5/10
        [HttpGet("{provinciaID}/{localidadID}")]
        public async Task<ActionResult<Localidad>> GetLocalidad(string provinciaID, string localidadID)
        {
            var localidad = await _context.Localidad.FindAsync(provinciaID, localidadID);

            if (localidad == null)
            {
                return NotFound();
            }

            return localidad;
        }

        // PUT: api/Localidades/5/10
        [HttpPut("{provinciaID}/{localidadID}")]
        public async Task<IActionResult> PutLocalidad(string provinciaID, string localidadID, Localidad localidad)
        {
            if (provinciaID != localidad.ProvinciaID || localidadID != localidad.LocalidadID)
            {
                return BadRequest();
            }

            _context.Entry(localidad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalidadExists(provinciaID, localidadID))
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

        // GET FUNCIONA, FALTA EL RESTO POST ETC

        // POST: api/Localidades
        [HttpPost]
        public async Task<ActionResult<Localidad>> PostLocalidad(Localidad localidad)
        {
            _context.Localidad.Add(localidad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocalidad", new { id = localidad.LocalidadID }, localidad);
        }

        // DELETE: api/Localidades/5/10
        [HttpDelete("{provinciaID}/{localidadID}")]
        public async Task<ActionResult<Localidad>> DeleteLocalidad(string provinciaID, string localidadID)
        {
            var localidad = await _context.Localidad.FindAsync(provinciaID, localidadID);
            if (localidad == null)
            {
                return NotFound();
            }

            _context.Localidad.Remove(localidad);
            await _context.SaveChangesAsync();

            return localidad;
        }

        private bool LocalidadExists(string provinciaID, string localidadID)
        {
            return _context.Localidad.Any(e => e.ProvinciaID == provinciaID && e.LocalidadID == localidadID);
        }
    }
}
