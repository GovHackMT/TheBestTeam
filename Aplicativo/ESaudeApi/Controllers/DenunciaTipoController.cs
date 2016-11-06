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
    [Route("api/DenunciaTipo")]
    public class DenunciaTipoController : Controller
    {
        private readonly DbESaudeApiContext _context;

        public DenunciaTipoController(DbESaudeApiContext context)
        {
            _context = context;
        }

        // GET: api/DenunciaTipo
        [HttpGet]
        public IEnumerable<DenunciaTipo> GetDenunciaTipo()
        {
            return _context.DenunciaTipo;
        }

        // GET: api/DenunciaTipo/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDenunciaTipo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DenunciaTipo denunciaTipo = await _context.DenunciaTipo.SingleOrDefaultAsync(m => m.IdDenunciaTipo == id);

            if (denunciaTipo == null)
            {
                return NotFound();
            }

            return Ok(denunciaTipo);
        }

        // PUT: api/DenunciaTipo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDenunciaTipo([FromRoute] int id, [FromBody] DenunciaTipo denunciaTipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != denunciaTipo.IdDenunciaTipo)
            {
                return BadRequest();
            }

            _context.Entry(denunciaTipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DenunciaTipoExists(id))
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

        // POST: api/DenunciaTipo
        [HttpPost]
        public async Task<IActionResult> PostDenunciaTipo([FromBody] DenunciaTipo denunciaTipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DenunciaTipo.Add(denunciaTipo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DenunciaTipoExists(denunciaTipo.IdDenunciaTipo))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDenunciaTipo", new { id = denunciaTipo.IdDenunciaTipo }, denunciaTipo);
        }

        // DELETE: api/DenunciaTipo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDenunciaTipo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DenunciaTipo denunciaTipo = await _context.DenunciaTipo.SingleOrDefaultAsync(m => m.IdDenunciaTipo == id);
            if (denunciaTipo == null)
            {
                return NotFound();
            }

            _context.DenunciaTipo.Remove(denunciaTipo);
            await _context.SaveChangesAsync();

            return Ok(denunciaTipo);
        }

        private bool DenunciaTipoExists(int id)
        {
            return _context.DenunciaTipo.Any(e => e.IdDenunciaTipo == id);
        }
    }
}