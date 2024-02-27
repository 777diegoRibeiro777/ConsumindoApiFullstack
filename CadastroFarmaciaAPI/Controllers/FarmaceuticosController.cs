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
    public class FarmaceuticosController : ControllerBase
    {
        private readonly CadastroFarmaciaDbContext _context;

        public FarmaceuticosController(CadastroFarmaciaDbContext context)
        {
            _context = context;
        }

        // GET: api/Farmaceuticos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Farmaceutico>>> GetFarmaceuticos()
        {
          if (_context.Farmaceuticos == null)
          {
              return NotFound();
          }
            return await _context.Farmaceuticos.ToListAsync();
        }

        // GET: api/Farmaceuticos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Farmaceutico>> GetFarmaceutico(int id)
        {
          if (_context.Farmaceuticos == null)
          {
              return NotFound();
          }
            var farmaceutico = await _context.Farmaceuticos.FindAsync(id);

            if (farmaceutico == null)
            {
                return NotFound();
            }

            return farmaceutico;
        }

        // PUT: api/Farmaceuticos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFarmaceutico(int id, Farmaceutico farmaceutico)
        {
            if (id != farmaceutico.Idfarmacutico)
            {
                return BadRequest();
            }

            _context.Entry(farmaceutico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FarmaceuticoExists(id))
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

        // POST: api/Farmaceuticos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Farmaceutico>> PostFarmaceutico(Farmaceutico farmaceutico)
        {
          if (_context.Farmaceuticos == null)
          {
              return Problem("Entity set 'CadastroFarmaciaDbContext.Farmaceuticos'  is null.");
          }
            _context.Farmaceuticos.Add(farmaceutico);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FarmaceuticoExists(farmaceutico.Idfarmacutico))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFarmaceutico", new { id = farmaceutico.Idfarmacutico }, farmaceutico);
        }

        // DELETE: api/Farmaceuticos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFarmaceutico(int id)
        {
            if (_context.Farmaceuticos == null)
            {
                return NotFound();
            }
            var farmaceutico = await _context.Farmaceuticos.FindAsync(id);
            if (farmaceutico == null)
            {
                return NotFound();
            }

            _context.Farmaceuticos.Remove(farmaceutico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FarmaceuticoExists(int id)
        {
            return (_context.Farmaceuticos?.Any(e => e.Idfarmacutico == id)).GetValueOrDefault();
        }
    }
}
