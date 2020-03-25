using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarProductServiceModel.Data;
using CarProductServiceModel.Models;
using CarProductServiceLogic.Logics;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;

namespace CarProductServiceController.Controllers
{
    // OData Swagger 統合プロジェクト 参考
    // https://github.com/hassanhabib/OData3.1WithSwagger

    [Produces("application/json")]
    // [Route("odata/[controller]")]
    [Route("api/[controller]")]
    // [ODataRoutePrefix("CarMaker")]
    [ApiController]
    // [ApiExplorerSettings(IgnoreApi = false)]
    public class CarProductServiceController : ControllerBase
    {
        private readonly CarProductServiceContext _context;

        private readonly CarMakerLogic _logic;

        public CarProductServiceController(CarProductServiceContext context)
        {
            _context = context;
            _logic = new CarMakerLogic(context);
        }

        // GET: api/CarProductService
        [HttpGet]
        // [ODataRoute]
        // [EnableQuery]
        public async Task<ActionResult<IEnumerable<CarMaker>>> GetCarMaker()
        {
            // return await _context.CarMaker.ToListAsync();
            return Ok(await _logic.GetCarMakerAsync());
        }

        // GET: api/CarProductService/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarMaker>> GetCarMaker(int id)
        {
            // var carMaker = await _context.CarMaker.FindAsync(id);
            var carMaker = await _logic.GetCarMakerAsync(id);

            if (carMaker == null)
            {
                return NotFound();
            }

            return carMaker;
        }

        // PUT: api/CarProductService/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarMaker(int id, CarMaker carMaker)
        {
            if (id != carMaker.MakerId)
            {
                return BadRequest();
            }

            // _context.Entry(carMaker).State = EntityState.Modified;

            try
            {
                // await _context.SaveChangesAsync();
                await _logic.PutCarMakerAsync(id, carMaker);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarMakerExists(id))
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

        // POST: api/CarProductService
        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <param name="carMaker">Parameter is Car Maker Model</param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>            
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CarMaker>> PostCarMaker(CarMaker carMaker)
        {
            // _context.CarMaker.Add(carMaker);
            // await _context.SaveChangesAsync();
            await _logic.PostCarMakerAsync(carMaker);

            return CreatedAtAction(nameof(GetCarMaker), new { id = carMaker.MakerId }, carMaker);
        }

        // DELETE: api/CarProductService/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarMaker>> DeleteCarMaker(int id)
        {
            // var carMaker = await _context.CarMaker.FindAsync(id);
            var carMaker = await _logic.DeleteCarMakerAsync(id);
            
            if (carMaker == null)
            {
                return NotFound();
            }

            // _context.CarMaker.Remove(carMaker);
            // await _context.SaveChangesAsync();

            return carMaker;
        }

        private bool CarMakerExists(int id)
        {
            return _context.CarMaker.Any(e => e.MakerId == id);
        }
    }
}
