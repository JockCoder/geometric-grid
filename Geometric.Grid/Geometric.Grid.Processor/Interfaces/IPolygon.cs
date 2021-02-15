using Geometric.Grid.Processor.Shapes.Math;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geometric.Grid.Processor.Interfaces
{
    public interface IPolygon
    {
        List<XYCoordinate> Vertices { get; }
    }
}
