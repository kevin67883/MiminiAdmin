using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiminiAdmin.Models;


namespace MiminiAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblRegistroVentasController : ControllerBase
    {
        private readonly MyDbContext _context;

        public TblRegistroVentasController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/TblRegistroVentas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblRegistroVentas>>> GetAll()
        {
            return await _context.TblRegistroVentas.ToListAsync();
        }

        // GET: api/TblRegistroVentas/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TblRegistroVentas>> GetById(int id)
        {
            var venta = await _context.TblRegistroVentas.FindAsync(id);

            if (venta == null)
                return NotFound();

            return venta;
        }

        // PUT: api/TblRegistroVentas/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, TblRegistroVentas venta)
        {
            if (id != venta.IdRegistro)
                return BadRequest("El ID del registro no coincide con el objeto enviado.");

            _context.Entry(venta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TblRegistroVentasExists(id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        // POST: api/TblRegistroVentas
        [HttpPost]
        public async Task<ActionResult<TblRegistroVentas>> Create(TblRegistroVentas venta)
        {
            _context.TblRegistroVentas.Add(venta);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = venta.IdRegistro }, venta);
        }

        // DELETE: api/TblRegistroVentas/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var venta = await _context.TblRegistroVentas.FindAsync(id);
            if (venta == null)
                return NotFound();

            _context.TblRegistroVentas.Remove(venta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> TblRegistroVentasExists(int id)
        {
            return await _context.TblRegistroVentas.AnyAsync(e => e.IdRegistro == id);
        }
    }
}
