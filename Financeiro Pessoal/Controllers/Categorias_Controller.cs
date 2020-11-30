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
    [Route(API.CategoriaApi)]
    [ApiController]
    public class Categorias_Controller : ControllerBase
    {
        private readonly AppDb _context;

        public Categorias_Controller(AppDb context)
        {
            _context = context;
        }

        [HttpGet]        
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            return await GetPesquisar(string.Empty);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categorias = await GetPesquisar(id.ToString());
            var categoria = categorias.Value.FirstOrDefault(x => x.ID == id);

            if (categoria == null) return NotFound();

            return categoria;
        }

        [Route("{action}/{info}")]
        [HttpGet("{info}")]        
        public async Task<ActionResult<IEnumerable<Categoria>>> GetPesquisar(string info)
        {
            info = API.DecodificarString(info);
            int id = API.DecodificarID(info);

            var categorias = await _context.Categorias
                .Where(x => x.ID == id || x.Descricao.ToLower().Contains(info))
                .ToListAsync();
                                                    
            return categorias;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (id != categoria.ID) return BadRequest();

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoria", new { id = categoria.ID }, categoria);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Categoria>> DeleteCategoria(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null) return NotFound();

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return categoria;
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.ID == id);
        }
    }
}
