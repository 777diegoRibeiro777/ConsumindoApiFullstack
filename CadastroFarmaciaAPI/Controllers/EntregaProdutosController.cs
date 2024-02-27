using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CadastroFarmaciaAPI.Context;
using CadastroFarmaciaAPI.Models;

namespace CadastroFarmaciaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntregaProdutosController : ControllerBase
    {
        private readonly CadastroFarmaciaDbContext _context;

        public EntregaProdutosController(CadastroFarmaciaDbContext context)
        {
            _context = context;
        }

        // GET: api/EntregaProdutos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntregaProduto>>> GetEntregaProdutos()
        {
          if (_context.EntregaProdutos == null)
          {
              return NotFound();
          }
            return await _context.EntregaProdutos.ToListAsync();
        }

        // GET: api/EntregaProdutos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntregaProduto>> GetEntregaProduto(int id)
        {
          if (_context.EntregaProdutos == null)
          {
              return NotFound();
          }
            var entregaProduto = await _context.EntregaProdutos.FindAsync(id);

            if (entregaProduto == null)
            {
                return NotFound();
            }

            return entregaProduto;
        }

        // PUT: api/EntregaProdutos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntregaProduto(int id, EntregaProduto entregaProduto)
        {
            if (id != entregaProduto.Identrega)
            {
                return BadRequest();
            }

            _context.Entry(entregaProduto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntregaProdutoExists(id))
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

        // POST: api/EntregaProdutos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EntregaProduto>> PostEntregaProduto(EntregaProduto entregaProduto)
        {
          if (_context.EntregaProdutos == null)
          {
              return Problem("Entity set 'CadastroFarmaciaDbContext.EntregaProdutos'  is null.");
          }
            _context.EntregaProdutos.Add(entregaProduto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EntregaProdutoExists(entregaProduto.Identrega))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEntregaProduto", new { id = entregaProduto.Identrega }, entregaProduto);
        }

        // DELETE: api/EntregaProdutos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntregaProduto(int id)
        {
            if (_context.EntregaProdutos == null)
            {
                return NotFound();
            }
            var entregaProduto = await _context.EntregaProdutos.FindAsync(id);
            if (entregaProduto == null)
            {
                return NotFound();
            }

            _context.EntregaProdutos.Remove(entregaProduto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntregaProdutoExists(int id)
        {
            return (_context.EntregaProdutos?.Any(e => e.Identrega == id)).GetValueOrDefault();
        }
    }
}
