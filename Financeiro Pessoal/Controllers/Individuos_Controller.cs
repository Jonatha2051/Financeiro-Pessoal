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

        [Route("{action}/{id}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Individuo>> GetIndividuo(int id)
        {
            var individuos = await GetPesquisar(id.ToString());            
            var individuo = individuos.Value.FirstOrDefault(x => x.ID == id);

            if (individuo == null) return NotFound();

            return individuo;
        }

        [Route("{action}/{info}")]
        [HttpGet("{info}")]
        public async Task<ActionResult<IEnumerable<Individuo>>> GetPesquisar(string info)
        {
            info = API.DecodificarString(info);
            int id = 0;

            var individuos = await _context.Individuos
                .Where(x => x.ID == id || x.Nome.ToLower().Contains(info) || x.Telefone.ToLower().Contains(info))
                .ToListAsync();

            return individuos;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutIndividuo(int id, Individuo individuo)
        {
            if (id != individuo.ID) return BadRequest();

            _context.Entry(individuo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndividuoExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

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
            if (individuo == null) return NotFound();

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
