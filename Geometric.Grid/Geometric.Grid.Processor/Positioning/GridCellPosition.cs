namespace Geometric.Grid.Processor.Positioning
{
    public class GridCellPosition
    {
        public int Column { get; }
        public int Row { get; }

        //Both Rows and Columns start at Base = 1
        public GridCellPosition(int column, int row)
        {
            if((column < 1) || (row < 1))
            {
                throw new System.ArgumentOutOfRangeException();
            }

            Column = column;
            Row = row;
        }
    }
}
