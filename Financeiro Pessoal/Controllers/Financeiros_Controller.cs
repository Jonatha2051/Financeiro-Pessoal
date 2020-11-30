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

        [Route("{action}/{id}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Financeiro>> GetFinanceiro(int id)
        {
            var financeiro = await GetPesquisar(id.ToString());
            var titulo = financeiro.Value.FirstOrDefault(x => x.ID == id);

            if (titulo == null) return NotFound();

            return titulo;
        }

        [Route("{action}/{info}")]
        [HttpGet("{info}")]
        public async Task<ActionResult<IEnumerable<Financeiro>>> GetPesquisar(string info)
        {
            info = API.DecodificarString(info);
            int id = API.DecodificarID(info);

            var financeiro = await _context.Financeiro
                .Include(x => x.Categoria)
                .Include(x => x.Individuo)
                .Where(x => x.ID == id || x.Descricao.ToLower().Contains(info))
                .ToListAsync();

            return financeiro;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinanceiro(int id, Financeiro financeiro)
        {
            if (id != financeiro.ID) return BadRequest();

            //Limpando as coleções:
            financeiro.Categoria = null;
            financeiro.Individuo = null;

            if (financeiro.IndividuoID == 0) financeiro.IndividuoID = null;

            _context.Entry(financeiro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinanceiroExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

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

        [HttpDelete("{id}")]
        public async Task<ActionResult<Financeiro>> DeleteFinanceiro(int id)
        {
            var financeiro = await _context.Financeiro.FindAsync(id);
            if (financeiro == null) return NotFound();

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
