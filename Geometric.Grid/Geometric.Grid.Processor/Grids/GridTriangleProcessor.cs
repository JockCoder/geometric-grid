using Geometric.Grid.Processor.Interfaces;
using Geometric.Grid.Processor.Shapes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geometric.Grid.Processor.Grids
{
    public class GridTriangleProcessor : IGridShapeProcessor
    {
        public GridCellPosition GetGridCellPosition(Shape shape)
        {
            throw new NotImplementedException();
        }

        public Shape GetShape(GridCellPosition gridCellPosition)
        {
            throw new NotImplementedException();
        }

        public bool ValidateGridCellPosition(GridCellPosition gridCellPosition)
        {
            throw new NotImplementedException();
        }

        public bool ValidateShape(Shape shape)
        {
            throw new NotImplementedException();
        }
    }
}
