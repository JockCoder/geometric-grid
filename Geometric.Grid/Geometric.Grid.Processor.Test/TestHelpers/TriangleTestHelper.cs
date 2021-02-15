using Geometric.Grid.Processor.Shapes.Models;

namespace Geometric.Grid.Processor.Test.TestHelpers
{
    public static class TriangleTestHelper
    {
        public static bool TestTriangleValues(Triangle expected, Triangle actual)
        {
            return XYCoordinateTestHelper.TestXYCoordinateValues(expected.Vertices[0], actual.Vertices[0]) &&
                XYCoordinateTestHelper.TestXYCoordinateValues(expected.Vertices[1], actual.Vertices[1]) &&
                XYCoordinateTestHelper.TestXYCoordinateValues(expected.Vertices[2], actual.Vertices[2]);
        }
    }
}
