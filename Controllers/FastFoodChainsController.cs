using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fast_Food_Chains_Web_API.Model;
using Fast_Food_Chains_Web_API.Models;

namespace Fast_Food_Chains_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FastFoodChainsController : ControllerBase
    {
        private readonly Fast_Food_Chains_Context _context;

        public FastFoodChainsController(Fast_Food_Chains_Context context)
        {
            _context = context;
        }

        // GET: api/FastFoodChains
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FastFoodChain>>> GetFastFoodChain()
        {
            return await (from fastFood in _context.FastFoodChain select fastFood).ToListAsync();
        }

        // GET: api/FastFoodChains/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FastFoodChain>> GetFastFoodChain(int id)
        {
            var fastFoodChain = await _context.FastFoodChain.FindAsync(id);

            if (fastFoodChain == null)
            {
                return NotFound();
            }

            return fastFoodChain;
        }

        // PUT: api/FastFoodChains/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFastFoodChain(int id, FastFoodChain fastFoodChain)
        {
            if (id != fastFoodChain.Id)
            {
                return BadRequest();
            }

            _context.Entry(fastFoodChain).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FastFoodChainExists(id))
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

        // POST: api/FastFoodChains
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<FastFoodChain>> PostFastFoodChain(FastFoodChain fastFoodChain)
        {
            _context.FastFoodChain.Add(fastFoodChain);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFastFoodChain", new { id = fastFoodChain.Id }, fastFoodChain);
        }

        // DELETE: api/FastFoodChains/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FastFoodChain>> DeleteFastFoodChain(int id)
        {
            var fastFoodChain = await _context.FastFoodChain.FindAsync(id);
            if (fastFoodChain == null)
            {
                return NotFound();
            }

            _context.FastFoodChain.Remove(fastFoodChain);
            await _context.SaveChangesAsync();

            return fastFoodChain;
        }

        private bool FastFoodChainExists(int id)
        {
            return _context.FastFoodChain.Any(e => e.Id == id);
        }
    }
}
