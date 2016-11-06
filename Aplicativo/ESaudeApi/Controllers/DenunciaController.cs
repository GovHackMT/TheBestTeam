using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ESaudeApi.Data;
using ESaudeApi.Models;

namespace AppSaude.Controllers
{
    [Produces("application/json")]
    [Route("api/Denuncia")]
    public class DenunciaController : Controller
    {
        private readonly DbESaudeApiContext _context;

        public DenunciaController(DbESaudeApiContext context)
        {
            _context = context;
        }

        // GET: api/Denuncia
        [HttpGet]
        public IEnumerable<Denuncia> GetDenuncia()
        {
            return _context.Denuncia;
        }

        // GET: api/Denuncia/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDenuncia([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Denuncia denuncia = await _context.Denuncia.SingleOrDefaultAsync(m => m.IdDenuncia == id);

            if (denuncia == null)
            {
                return NotFound();
            }

            return Ok(denuncia);
        }

        // PUT: api/Denuncia/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDenuncia([FromRoute] int id, [FromBody] Denuncia denuncia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != denuncia.IdDenuncia)
            {
                return BadRequest();
            }

            _context.Entry(denuncia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DenunciaExists(id))
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

        // POST: api/Denuncia
        [HttpPost]
        public async Task<IActionResult> PostDenuncia([FromBody] Denuncia denuncia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Denuncia.Add(denuncia);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DenunciaExists(denuncia.IdDenuncia))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDenuncia", new { id = denuncia.IdDenuncia }, denuncia);
        }

        // DELETE: api/Denuncia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDenuncia([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Denuncia denuncia = await _context.Denuncia.SingleOrDefaultAsync(m => m.IdDenuncia == id);
            if (denuncia == null)
            {
                return NotFound();
            }

            _context.Denuncia.Remove(denuncia);
            await _context.SaveChangesAsync();

            return Ok(denuncia);
        }

        private bool DenunciaExists(int id)
        {
            return _context.Denuncia.Any(e => e.IdDenuncia == id);
        }
    }
}