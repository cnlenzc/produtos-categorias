using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Entities;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly DadosContext _context;

        public ProdutoController(DadosContext context)
        {
            _context = context;
        }

        // GET: api/Produto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<produto>>> Getproduto()
        {
            return await _context.produto.OrderBy(p => p.descricao).ToListAsync();
        }

        // GET: api/Produto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<produto>> Getproduto(int id)
        {
            var produto = await _context.produto.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        // PUT: api/Produto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putproduto(int id, produto produto)
        {
            if (id != produto.id)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!produtoExists(id))
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

        // POST: api/Produto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<produto>> Postproduto(produto produto)
        {
            _context.produto.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getproduto", new { id = produto.id }, produto);
        }

        // DELETE: api/Produto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteproduto(int id)
        {
            var produto = await _context.produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.produto.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool produtoExists(int id)
        {
            return _context.produto.Any(e => e.id == id);
        }
    }
}
