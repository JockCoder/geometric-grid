using Geometric.Grid.Processor.Grids;
using Geometric.Grid.Processor.Shapes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geometric.Grid.Processor.Interfaces
{
    public interface IGridShapeProcessor
    {
        IShape GetShape(GridCellPosition gridCellPosition);
        GridCellPosition GetGridCellPosition(IShape shape);
        bool ValidateGridCellPosition(GridCellPosition gridCellPosition);
        bool ValidateShape(IShape shape);

    }
}
