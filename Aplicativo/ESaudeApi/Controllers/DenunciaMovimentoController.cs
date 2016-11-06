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
    [Route("api/DenunciaMovimento")]
    public class DenunciaMovimentoController : Controller
    {
        private readonly DbESaudeApiContext _context;

        public DenunciaMovimentoController(DbESaudeApiContext context)
        {
            _context = context;
        }

        // GET: api/DenunciaMovimento
        [HttpGet]
        public IEnumerable<DenunciaMovimento> GetDenunciaMovimento()
        {
            return _context.DenunciaMovimento;
        }

        // GET: api/DenunciaMovimento/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDenunciaMovimento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DenunciaMovimento denunciaMovimento = await _context.DenunciaMovimento.SingleOrDefaultAsync(m => m.IdDenunciaMovimento == id);

            if (denunciaMovimento == null)
            {
                return NotFound();
            }

            return Ok(denunciaMovimento);
        }

        // PUT: api/DenunciaMovimento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDenunciaMovimento([FromRoute] int id, [FromBody] DenunciaMovimento denunciaMovimento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != denunciaMovimento.IdDenunciaMovimento)
            {
                return BadRequest();
            }

            _context.Entry(denunciaMovimento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DenunciaMovimentoExists(id))
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

        // POST: api/DenunciaMovimento
        [HttpPost]
        public async Task<IActionResult> PostDenunciaMovimento([FromBody] DenunciaMovimento denunciaMovimento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DenunciaMovimento.Add(denunciaMovimento);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DenunciaMovimentoExists(denunciaMovimento.IdDenunciaMovimento))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDenunciaMovimento", new { id = denunciaMovimento.IdDenunciaMovimento }, denunciaMovimento);
        }

        // DELETE: api/DenunciaMovimento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDenunciaMovimento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DenunciaMovimento denunciaMovimento = await _context.DenunciaMovimento.SingleOrDefaultAsync(m => m.IdDenunciaMovimento == id);
            if (denunciaMovimento == null)
            {
                return NotFound();
            }

            _context.DenunciaMovimento.Remove(denunciaMovimento);
            await _context.SaveChangesAsync();

            return Ok(denunciaMovimento);
        }

        private bool DenunciaMovimentoExists(int id)
        {
            return _context.DenunciaMovimento.Any(e => e.IdDenunciaMovimento == id);
        }
    }
}