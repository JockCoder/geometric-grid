using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Geometric.Grid.Processor.Shapes.Models;
using Geometric.Grid.Processor.Positioning;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Geometric.Grid.Api.Controllers
{
    [Route("api/grid/[controller]")]
    [ApiController]
    public class TriangleController : ControllerBase
    {
        // GET: api/<TriangleController>
        [HttpGet]
        public IActionResult Get([FromQuery] GridCellTranslator gridLocation)
        {
            //return new string[] { "value1", "value2" };

            XYCoordinate Vertex1 = new XYCoordinate(1, 1);
            XYCoordinate Vertex2 = new XYCoordinate(1, 2);
            XYCoordinate Vertex3 = new XYCoordinate(2, 1);

            Triangle triangle =  new Triangle(
                new List<XYCoordinate>() {
                    Vertex1,
                    Vertex2,
                    Vertex3 }
                );

            //return Ok(triangle);

            //return Ok();

            string ret = string.Format("Row = {0}, Col = {1}, nRow = {2}, nColumn = {3}",
                gridLocation.Row, gridLocation.Column, gridLocation.GetRow(), gridLocation.GetColumn());

            return Ok(ret);

            //return Ok(gridLocation);
        }

        // GET api/<TriangleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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

        // DELETE api/<TriangleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
