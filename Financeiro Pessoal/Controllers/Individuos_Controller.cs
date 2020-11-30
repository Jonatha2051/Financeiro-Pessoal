using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Financeiro_Pessoal.Data;
using Financeiro_Pessoal.Models;
using Financeiro_Pessoal.Helpers;

namespace Financeiro_Pessoal.Controllers
{
    [Route(API.IndividuoApi)]
    [ApiController]
    public class Individuos_Controller : ControllerBase
    {
        private readonly AppDb _context;

        public Individuos_Controller(AppDb context)
        {
            _context = context;
        }

        // GET: api/Individuos_
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Individuo>>> GetIndividuos()
        {
            return await _context.Individuos.ToListAsync();
        }

        // GET: api/Individuos_/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Individuo>> GetIndividuo(int id)
        {
            var individuo = await _context.Individuos.FindAsync(id);

            if (individuo == null)
            {
                return NotFound();
            }

            return individuo;
        }

        [HttpGet("{id}/{info}")]
        public async Task<ActionResult<IEnumerable<Individuo>>> GetIndividuosPesquisa(int id, string info)
        {            
            var individuos = await _context.Individuos
                .Where(x => x.ID == id || x.Nome.ToLower().Contains(info) || x.Telefone.ToLower().Contains(info))
                .ToListAsync();

            return individuos;
        }

        // PUT: api/Individuos_/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIndividuo(int id, Individuo individuo)
        {
            if (id != individuo.ID)
            {
                return BadRequest();
            }

            _context.Entry(individuo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndividuoExists(id))
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

        // POST: api/Individuos_
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Individuo>> PostIndividuo(Individuo individuo)
        {
            try
            {
                _context.Individuos.Add(individuo);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetIndividuo", new { id = individuo.ID }, individuo);
            }
            catch (Exception e)
            {

                throw e;
            }            
        }

        // DELETE: api/Individuos_/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Individuo>> DeleteIndividuo(int id)
        {
            var individuo = await _context.Individuos.FindAsync(id);
            if (individuo == null)
            {
                return NotFound();
            }

            _context.Individuos.Remove(individuo);
            await _context.SaveChangesAsync();

            return individuo;
        }

        private bool IndividuoExists(int id)
        {
            return _context.Individuos.Any(e => e.ID == id);
        }
    }
}
