using Geometric.Grid.Processor.Positioning;
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
