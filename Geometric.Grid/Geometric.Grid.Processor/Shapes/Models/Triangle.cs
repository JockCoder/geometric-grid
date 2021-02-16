using System;
using System.Collections.Generic;

using Geometric.Grid.Processor.Positioning;

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
