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
    public class ProdutosFarmaceuticosController : ControllerBase
    {
        private readonly CadastroFarmaciaDbContext _context;

        public ProdutosFarmaceuticosController(CadastroFarmaciaDbContext context)
        {
            _context = context;
        }

        // GET: api/ProdutosFarmaceuticos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoFarmaceutico>>> GetProdutoFarmaceuticos()
        {
          if (_context.ProdutoFarmaceuticos == null)
          {
              return NotFound();
          }
            return await _context.ProdutoFarmaceuticos.ToListAsync();
        }

        // GET: api/ProdutosFarmaceuticos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoFarmaceutico>> GetProdutoFarmaceutico(int id)
        {
          if (_context.ProdutoFarmaceuticos == null)
          {
              return NotFound();
          }
            var produtoFarmaceutico = await _context.ProdutoFarmaceuticos.FindAsync(id);

            if (produtoFarmaceutico == null)
            {
                return NotFound();
            }

            return produtoFarmaceutico;
        }

        // PUT: api/ProdutosFarmaceuticos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdutoFarmaceutico(int id, ProdutoFarmaceutico produtoFarmaceutico)
        {
            if (id != produtoFarmaceutico.Idproduto)
            {
                return BadRequest();
            }

            _context.Entry(produtoFarmaceutico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoFarmaceuticoExists(id))
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

        // POST: api/ProdutosFarmaceuticos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProdutoFarmaceutico>> PostProdutoFarmaceutico(ProdutoFarmaceutico produtoFarmaceutico)
        {
          if (_context.ProdutoFarmaceuticos == null)
          {
              return Problem("Entity set 'CadastroFarmaciaDbContext.ProdutoFarmaceuticos'  is null.");
          }
            _context.ProdutoFarmaceuticos.Add(produtoFarmaceutico);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProdutoFarmaceuticoExists(produtoFarmaceutico.Idproduto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProdutoFarmaceutico", new { id = produtoFarmaceutico.Idproduto }, produtoFarmaceutico);
        }

        // DELETE: api/ProdutosFarmaceuticos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdutoFarmaceutico(int id)
        {
            if (_context.ProdutoFarmaceuticos == null)
            {
                return NotFound();
            }
            var produtoFarmaceutico = await _context.ProdutoFarmaceuticos.FindAsync(id);
            if (produtoFarmaceutico == null)
            {
                return NotFound();
            }

            _context.ProdutoFarmaceuticos.Remove(produtoFarmaceutico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutoFarmaceuticoExists(int id)
        {
            return (_context.ProdutoFarmaceuticos?.Any(e => e.Idproduto == id)).GetValueOrDefault();
        }
    }
}
