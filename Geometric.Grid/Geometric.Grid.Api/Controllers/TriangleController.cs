using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

using Geometric.Grid.Processor.Interfaces;
using Geometric.Grid.Processor.Shapes.Models;
using Geometric.Grid.Processor.Positioning;
using Geometric.Grid.Processor.Grids;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Geometric.Grid.Api.Controllers
{
    [Route("api/grid/[controller]")]
    [ApiController]
    public class TriangleController : ControllerBase
    {
        private readonly ILogger<TriangleController> _logger;

        public TriangleController(ILogger<TriangleController> logger)
        {
            _logger = logger;
        }


        // GET: api/<TriangleController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Triangle))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get([FromQuery] GridCellTranslator gridLocation)
        {
            IGridShapeProcessor processor = new Grid12x6RightAngleTriangleProcessor();

            try
            {
                //First Convert from the mapped valudes to actual numer grid values
                GridCellPosition position = new GridCellPosition(gridLocation.GetNumericColumn(), 
                                                                 gridLocation.GetNumericRow());

                //Check that the position is valid
                if(processor.ValidateGridCellPosition(position))
                {
                    //Yep, all's Ok
                    IShape triangle = processor.GetShape(position);
                    return Ok(triangle);
                }
                else
                {
                    //Not found
                    return NotFound();
                }
                
            }
            catch (Exception ex)
            {
                //log something here
                _logger.LogError(ex.Message);
            }

            //Something has gone wrong.
            return BadRequest();
        }


        // POST api/<TriangleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TriangleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

    }
}
