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
    [Route("api/DenunciaMovimentoTipo")]
    public class DenunciaMovimentoTipoController : Controller
    {
        private readonly DbESaudeApiContext _context;

        public DenunciaMovimentoTipoController(DbESaudeApiContext context)
        {
            _context = context;
        }

        // GET: api/DenunciaMovimentoTipo
        [HttpGet]
        public IEnumerable<DenunciaMovimentoTipo> GetDenunciaMovimentoTipo()
        {
            return _context.DenunciaMovimentoTipo;
        }

        // GET: api/DenunciaMovimentoTipo/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDenunciaMovimentoTipo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DenunciaMovimentoTipo denunciaMovimentoTipo = await _context.DenunciaMovimentoTipo.SingleOrDefaultAsync(m => m.IdDenunciaMovimentoTipo == id);

            if (denunciaMovimentoTipo == null)
            {
                return NotFound();
            }

            return Ok(denunciaMovimentoTipo);
        }

        // PUT: api/DenunciaMovimentoTipo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDenunciaMovimentoTipo([FromRoute] int id, [FromBody] DenunciaMovimentoTipo denunciaMovimentoTipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != denunciaMovimentoTipo.IdDenunciaMovimentoTipo)
            {
                return BadRequest();
            }

            _context.Entry(denunciaMovimentoTipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DenunciaMovimentoTipoExists(id))
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

        // POST: api/DenunciaMovimentoTipo
        [HttpPost]
        public async Task<IActionResult> PostDenunciaMovimentoTipo([FromBody] DenunciaMovimentoTipo denunciaMovimentoTipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DenunciaMovimentoTipo.Add(denunciaMovimentoTipo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DenunciaMovimentoTipoExists(denunciaMovimentoTipo.IdDenunciaMovimentoTipo))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDenunciaMovimentoTipo", new { id = denunciaMovimentoTipo.IdDenunciaMovimentoTipo }, denunciaMovimentoTipo);
        }

        // DELETE: api/DenunciaMovimentoTipo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDenunciaMovimentoTipo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DenunciaMovimentoTipo denunciaMovimentoTipo = await _context.DenunciaMovimentoTipo.SingleOrDefaultAsync(m => m.IdDenunciaMovimentoTipo == id);
            if (denunciaMovimentoTipo == null)
            {
                return NotFound();
            }

            _context.DenunciaMovimentoTipo.Remove(denunciaMovimentoTipo);
            await _context.SaveChangesAsync();

            return Ok(denunciaMovimentoTipo);
        }

        private bool DenunciaMovimentoTipoExists(int id)
        {
            return _context.DenunciaMovimentoTipo.Any(e => e.IdDenunciaMovimentoTipo == id);
        }
    }
}