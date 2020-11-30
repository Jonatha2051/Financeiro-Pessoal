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
    [Route(API.FinanceiroApi)]
    [ApiController]
    public class Financeiros_Controller : ControllerBase
    {
        private readonly AppDb _context;

        public Financeiros_Controller(AppDb context)
        {
            _context = context;
        }

        // GET: api/Financeiros_
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Financeiro>>> GetFinanceiro()
        {
            return await _context.Financeiro.Include(x => x.Categoria).Include(x => x.Individuo).ToListAsync();
        }

        // GET: api/Financeiros_/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Financeiro>> GetFinanceiro(int id)
        {
            var financeiro = await _context.Financeiro.Include(x => x.Categoria).Include(x => x.Individuo).FirstOrDefaultAsync(x => x.ID == id);

            if (financeiro == null)
            {
                return NotFound();
            }

            return financeiro;
        }

        // PUT: api/Financeiros_/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinanceiro(int id, Financeiro financeiro)
        {
            if (id != financeiro.ID)
            {
                return BadRequest();
            }

            _context.Entry(financeiro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinanceiroExists(id))
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

        // POST: api/Financeiros_
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Financeiro>> PostFinanceiro(Financeiro financeiro)
        {
            try
            {
                _context.Financeiro.Add(financeiro);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetFinanceiro", new { id = financeiro.ID }, financeiro);
            }
            catch (Exception e)
            {

                throw e;
            }            
        }

        // DELETE: api/Financeiros_/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Financeiro>> DeleteFinanceiro(int id)
        {
            var financeiro = await _context.Financeiro.FindAsync(id);
            if (financeiro == null)
            {
                return NotFound();
            }

            _context.Financeiro.Remove(financeiro);
            await _context.SaveChangesAsync();

            return financeiro;
        }

        private bool FinanceiroExists(int id)
        {
            return _context.Financeiro.Any(e => e.ID == id);
        }
    }
}
