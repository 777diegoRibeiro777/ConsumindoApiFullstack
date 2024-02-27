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
    public class VendasProdutosController : ControllerBase
    {
        private readonly CadastroFarmaciaDbContext _context;

        public VendasProdutosController(CadastroFarmaciaDbContext context)
        {
            _context = context;
        }

        // GET: api/VendasProdutos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendaProduto>>> GetVendaProdutos()
        {
          if (_context.VendaProdutos == null)
          {
              return NotFound();
          }
            return await _context.VendaProdutos.ToListAsync();
        }

        // GET: api/VendasProdutos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VendaProduto>> GetVendaProduto(int id)
        {
          if (_context.VendaProdutos == null)
          {
              return NotFound();
          }
            var vendaProduto = await _context.VendaProdutos.FindAsync(id);

            if (vendaProduto == null)
            {
                return NotFound();
            }

            return vendaProduto;
        }

        // PUT: api/VendasProdutos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendaProduto(int id, VendaProduto vendaProduto)
        {
            if (id != vendaProduto.Idvenda)
            {
                return BadRequest();
            }

            _context.Entry(vendaProduto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendaProdutoExists(id))
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

        // POST: api/VendasProdutos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VendaProduto>> PostVendaProduto(VendaProduto vendaProduto)
        {
          if (_context.VendaProdutos == null)
          {
              return Problem("Entity set 'CadastroFarmaciaDbContext.VendaProdutos'  is null.");
          }
            _context.VendaProdutos.Add(vendaProduto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VendaProdutoExists(vendaProduto.Idvenda))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVendaProduto", new { id = vendaProduto.Idvenda }, vendaProduto);
        }

        // DELETE: api/VendasProdutos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendaProduto(int id)
        {
            if (_context.VendaProdutos == null)
            {
                return NotFound();
            }
            var vendaProduto = await _context.VendaProdutos.FindAsync(id);
            if (vendaProduto == null)
            {
                return NotFound();
            }

            _context.VendaProdutos.Remove(vendaProduto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VendaProdutoExists(int id)
        {
            return (_context.VendaProdutos?.Any(e => e.Idvenda == id)).GetValueOrDefault();
        }
    }
}
