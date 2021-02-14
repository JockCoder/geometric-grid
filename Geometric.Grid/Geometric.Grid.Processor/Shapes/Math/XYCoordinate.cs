using System;

namespace Geometric.Grid.Processor.Shapes.Math
{
    public class XYCoordinate
    {
        public int X { get; }
        public int Y { get; }

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
