using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ESaudeApi.Data;
using ESaudeApi.Models;
using Microsoft.AspNetCore.Routing;
using ESaudeApi.Tools;

namespace AppSaude.Controllers
{

    [Produces("application/json")]
    [Route("api/Usuario")]
    public class UsuarioController : Controller
    {
        private readonly DbESaudeApiContext _context;

        public UsuarioController(DbESaudeApiContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public IEnumerable<Usuario> GetUsuario()
        {
            return _context.Usuario;
        }
        [Route("AuthorizationUser")]
        [HttpGet]
        public IActionResult AuthorizationUser(string user, string password)
        {
            try
            {
                var registroUsuario = _context.Usuario.Where(x => x.Email == user).FirstOrDefault();

                if (registroUsuario == null)
                {
                    return Unauthorized();
                }
                else
                {
                    if (registroUsuario.Senha == password)
                    {
                        SessaoSistema.NewSession(HttpContext, new SessaoSistema()
                        {
                            IdUsuario = registroUsuario.IdUsuario,
                            Nome = registroUsuario.Nome,
                            SobreNome = registroUsuario.SobreNome,
                            Autenticacao = registroUsuario.Autenticacao,
                            Email = registroUsuario.Email
                        });

                        return Ok();
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Usuario usuario = await _context.Usuario.SingleOrDefaultAsync(m => m.IdUsuario == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // PUT: api/Usuarios/5
        [HttpPut]
        public async Task<IActionResult> PutUsuario([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(usuario.Email))
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

        // POST: api/Usuarios
        [HttpPost]
        public async Task<IActionResult> PostUsuario([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (UsuarioExists(usuario.Email))
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }

            _context.Usuario.Add(usuario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UsuarioExists(usuario.Email))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsuario", new { id = usuario.IdUsuario }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Usuario usuario = await _context.Usuario.SingleOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return Ok(usuario);
        }

        private bool UsuarioExists(string email)
        {
            return _context.Usuario.Any(e => e.Email == email);
        }

        [HttpGet]
        [Route("GetCurrentUser")]
        public IActionResult GetCurrentUser()
        {
            try
            {
                var sessao = SessaoSistema.GetSession(HttpContext);
                if(sessao != null)
                {
                    var registro = _context.Usuario.Where(x => x.IdUsuario == sessao.IdUsuario).FirstOrDefault();
                    if (registro != null)
                    {
                        return Ok(registro);
                    }else
                    {
                        return NotFound("Usuário não encontrado!");
                    }

                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            try
            {
                SessaoSistema.Logout(HttpContext);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}