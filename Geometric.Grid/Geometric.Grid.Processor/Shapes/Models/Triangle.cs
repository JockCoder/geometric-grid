using Geometric.Grid.Processor.Shapes.Math;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geometric.Grid.Processor.Shapes.Models
{
    public class Triangle: Polygon
    {
        public Triangle(List<XYCoordinate> vertices): base(vertices, "Triangle")
        {
            if(vertices.Count != 3)
            {
                throw new ArgumentException();
            }
        }
    }
}
