using Geometric.Grid.Processor.Positioning;
using System.Collections.Generic;

namespace Geometric.Grid.Processor.Interfaces
{
    public interface IPolygon
    {
        List<XYCoordinate> Vertices { get; }
    }
}
