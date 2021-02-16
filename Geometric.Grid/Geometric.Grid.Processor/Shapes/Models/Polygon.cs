using System;
using System.Collections.Generic;

using Geometric.Grid.Processor.Interfaces;
using Geometric.Grid.Processor.Positioning;

namespace Geometric.Grid.Processor.Shapes.Models
{
    public class Polygon: Shape, IPolygon
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
