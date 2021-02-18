using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

using Geometric.Grid.Processor.Interfaces;
using Geometric.Grid.Processor.Shapes.Models;
using Geometric.Grid.Processor.Positioning;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Geometric.Grid.Api.Controllers
{
    [Route("api/grid/[controller]")]
    [ApiController]
    public class TriangleController : ControllerBase
    {
        private readonly ILogger<TriangleController> _logger;
        private readonly IGridShapeProcessor _shapeProcessor;

        public TriangleController(ILogger<TriangleController> logger, IGridShapeProcessor gridShapeProcessor)
        {
            _logger = logger;
            _shapeProcessor = gridShapeProcessor;
        }


        // GET: api/<TriangleController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Triangle))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get([FromQuery] GridCellMapper gridMapper)
        {
            try
            {
                //First Convert from the mapped valudes to actual numeric grid values
                GridCellPosition position = new GridCellPosition(gridMapper.GetNumericColumn(), 
                                                                 gridMapper.GetNumericRow());

                //Check that the position is valid
                if(_shapeProcessor.ValidateGridCellPosition(position))
                {
                    //Yep, all's Ok - go get the shape
                    IShape triangle = _shapeProcessor.GetShape(position);
                    return Ok(triangle);
                }
                else
                {
                    //Not found
                    return NotFound();
                }
                
            }
            catch(ArgumentOutOfRangeException ex)
            {
                //Out of range - means not found
                _logger.LogError(ex.Message);
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            //Something has gone wrong.
            return BadRequest();
        }


        // POST api/<TriangleController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GridCellMapper))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Triangle triangle)
        {
            try
            {
                //Check that the triangle is valid
                if (_shapeProcessor.ValidateShape(triangle))
                {
                    //Yep, all's Ok
                    GridCellPosition position = _shapeProcessor.GetGridCellPosition(triangle);

                    GridCellMapper gridMapper = new GridCellMapper();

                    //Convert from numeric grid, to mapped grid values
                    gridMapper.SetGridMappedValues(position.Row, position.Column);

                    return Created(Request.Path.ToString(), gridMapper);
                }
                else
                {
                    //Not found
                    return NotFound();
                }

            }
            catch (ArgumentOutOfRangeException ex)
            {
                //Out of range - means not found
                _logger.LogError(ex.Message);
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            //Something has gone wrong.
            return BadRequest();
        }


    }
}
