using Geometric.Grid.Processor.Positioning;

namespace Geometric.Grid.Processor.Interfaces
{

    /// <summary>
    /// An interface of which concrete clients can implement the details
    /// of any type of grid system and the shapes within it.
    /// </summary>
    public interface IGridShapeProcessor
    {
        //Get the shape for the grid position given
        IShape GetShape(GridCellPosition gridCellPosition);

        //For a given shape, get the grid position it's in
        GridCellPosition GetGridCellPosition(IShape shape);

        //Validate the Grid Position Provided
        bool ValidateGridCellPosition(GridCellPosition gridCellPosition);

        //Validate the shape
        bool ValidateShape(IShape shape);

    }
}
