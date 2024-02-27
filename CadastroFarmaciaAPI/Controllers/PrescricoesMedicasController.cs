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
    public class PrescricoesMedicasController : ControllerBase
    {
        private readonly CadastroFarmaciaDbContext _context;

        public PrescricoesMedicasController(CadastroFarmaciaDbContext context)
        {
            _context = context;
        }

        // GET: api/PrescricoesMedicas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrescricaoMedica>>> GetPrescricaoMedicas()
        {
          if (_context.PrescricaoMedicas == null)
          {
              return NotFound();
          }
            return await _context.PrescricaoMedicas.ToListAsync();
        }

        // GET: api/PrescricoesMedicas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrescricaoMedica>> GetPrescricaoMedica(int id)
        {
          if (_context.PrescricaoMedicas == null)
          {
              return NotFound();
          }
            var prescricaoMedica = await _context.PrescricaoMedicas.FindAsync(id);

            if (prescricaoMedica == null)
            {
                return NotFound();
            }

            return prescricaoMedica;
        }

        // PUT: api/PrescricoesMedicas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrescricaoMedica(int id, PrescricaoMedica prescricaoMedica)
        {
            if (id != prescricaoMedica.Idprescricao)
            {
                return BadRequest();
            }

            _context.Entry(prescricaoMedica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrescricaoMedicaExists(id))
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

        // POST: api/PrescricoesMedicas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PrescricaoMedica>> PostPrescricaoMedica(PrescricaoMedica prescricaoMedica)
        {
          if (_context.PrescricaoMedicas == null)
          {
              return Problem("Entity set 'CadastroFarmaciaDbContext.PrescricaoMedicas'  is null.");
          }
            _context.PrescricaoMedicas.Add(prescricaoMedica);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PrescricaoMedicaExists(prescricaoMedica.Idprescricao))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPrescricaoMedica", new { id = prescricaoMedica.Idprescricao }, prescricaoMedica);
        }

        // DELETE: api/PrescricoesMedicas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescricaoMedica(int id)
        {
            if (_context.PrescricaoMedicas == null)
            {
                return NotFound();
            }
            var prescricaoMedica = await _context.PrescricaoMedicas.FindAsync(id);
            if (prescricaoMedica == null)
            {
                return NotFound();
            }

            _context.PrescricaoMedicas.Remove(prescricaoMedica);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrescricaoMedicaExists(int id)
        {
            return (_context.PrescricaoMedicas?.Any(e => e.Idprescricao == id)).GetValueOrDefault();
        }
    }
}
