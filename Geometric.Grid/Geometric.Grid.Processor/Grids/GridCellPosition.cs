namespace Geometric.Grid.Processor.Grids
{
    public class GridCellPosition
    {
        public int Column { get; }
        public int Row { get; }

        public GridCellPosition(int column, int row)
        {
            if((column < 0) || (row < 0))
            {
                throw new System.ArgumentOutOfRangeException();
            }

            Column = column;
            Row = row;
        }
    }
}
