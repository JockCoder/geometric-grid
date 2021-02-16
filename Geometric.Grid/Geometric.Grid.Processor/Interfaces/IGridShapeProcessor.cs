using Geometric.Grid.Processor.Positioning;

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
