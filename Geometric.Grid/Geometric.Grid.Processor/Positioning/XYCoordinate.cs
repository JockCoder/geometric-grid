using System;

namespace Geometric.Grid.Processor.Positioning
{
    public class XYCoordinate
    {
        public int X { get; }
        public int Y { get; }

        //Both Rows and Columns start at Base = 0
        public XYCoordinate(int x, int y)
        {
            if((x < 0) || (y < 0))
            {
                throw new ArgumentOutOfRangeException();
            }

            X = x;
            Y = y;
        }
    }
}
