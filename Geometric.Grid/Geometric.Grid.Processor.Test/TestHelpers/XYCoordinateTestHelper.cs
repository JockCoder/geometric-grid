using Geometric.Grid.Processor.Shapes.Math;

namespace Geometric.Grid.Processor.Test.TestHelpers
{
    public static class XYCoordinateTestHelper
    {
        public static bool TestXYCoordinateValues(XYCoordinate expected, XYCoordinate actual)
        {
            return expected.X == actual.X &&
                expected.Y == actual.Y;
        }
    }
}
