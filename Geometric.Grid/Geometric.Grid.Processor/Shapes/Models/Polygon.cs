using Geometric.Grid.Processor.Shapes.Math;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geometric.Grid.Processor.Shapes.Models
{
    public class Polygon: Shape
    {
        public List<XYCoordinate> Vertices { get; }

        public Polygon(List<XYCoordinate> vertices, string name):base(name)
        {
            if(vertices == null)
            {
                throw new ArgumentNullException();
            }

            Vertices = vertices;
        }

    }
}
