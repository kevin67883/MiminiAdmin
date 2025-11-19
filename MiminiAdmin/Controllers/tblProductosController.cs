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
    public class tblProductosController : ControllerBase
    {
        private readonly MyDbContext _context;

        public tblProductosController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/tblProductos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblProducto>>> GettblProducto()
        {
            return await _context.tblProducto.ToListAsync();
        }

        // GET: api/tblProductos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tblProducto>> GettblProducto(int id)
        {
            var tblProducto = await _context.tblProducto.FindAsync(id);

            if (tblProducto == null)
            {
                return NotFound();
            }

            return tblProducto;
        }

        // PUT: api/tblProductos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttblProducto(int id, tblProducto tblProducto)
        {
            if (id != tblProducto.idProducto)
            {
                return BadRequest();
            }

            _context.Entry(tblProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblProductoExists(id))
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

        // POST: api/tblProductos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tblProducto>> PosttblProducto(tblProducto tblProducto)
        {
            _context.tblProducto.Add(tblProducto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettblProducto", new { id = tblProducto.idProducto }, tblProducto);
        }

        // DELETE: api/tblProductos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetblProducto(int id)
        {
            var tblProducto = await _context.tblProducto.FindAsync(id);
            if (tblProducto == null)
            {
                return NotFound();
            }

            _context.tblProducto.Remove(tblProducto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tblProductoExists(int id)
        {
            return _context.tblProducto.Any(e => e.idProducto == id);
        }
    }
}
