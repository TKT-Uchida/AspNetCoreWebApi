using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MigrationTestModel;
using MigrationTestModel.Data;

namespace MigrationTestController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MigrationTestController : ControllerBase
    {
        private readonly MigrationTestContext _context;

        public MigrationTestController(MigrationTestContext context)
        {
            _context = context;
        }

        // GET: api/MigrationTest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductMst>>> GetCarMaker()
        {
            return await _context.CarMaker.ToListAsync();
        }

        // GET: api/MigrationTest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductMst>> GetProductMst(int id)
        {
            var productMst = await _context.CarMaker.FindAsync(id);

            if (productMst == null)
            {
                return NotFound();
            }

            return productMst;
        }

        // PUT: api/MigrationTest/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductMst(int id, ProductMst productMst)
        {
            if (id != productMst.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(productMst).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductMstExists(id))
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

        // POST: api/MigrationTest
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ProductMst>> PostProductMst(ProductMst productMst)
        {
            _context.CarMaker.Add(productMst);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductMst", new { id = productMst.ProductId }, productMst);
        }

        // DELETE: api/MigrationTest/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductMst>> DeleteProductMst(int id)
        {
            var productMst = await _context.CarMaker.FindAsync(id);
            if (productMst == null)
            {
                return NotFound();
            }

            _context.CarMaker.Remove(productMst);
            await _context.SaveChangesAsync();

            return productMst;
        }

        private bool ProductMstExists(int id)
        {
            return _context.CarMaker.Any(e => e.ProductId == id);
        }
    }
}
