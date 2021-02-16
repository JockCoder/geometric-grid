using Geometric.Grid.Processor.Positioning;

namespace Geometric.Grid.Processor.Test.TestHelpers
{
    public static class GridCellPositionTestHelper
    {
        public static bool TestGridCellPositionValues(GridCellPosition expected, GridCellPosition actual)
        {
            return expected.Column == actual.Column &&
                expected.Row == actual.Row;
        }
    }
}
