using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometric.Grid.Processor.Interfaces;
using Geometric.Grid.Processor.Grids;

namespace Geometric.Grid.Processor.Test
{
    /// <summary>
    /// Remember: Arrange, Act, Assert!
    /// </summary>
    [TestClass]
    public class GridTriangleProcessorTest
    {
        private IGridShapeProcessor gridShapeProcessor;

        [TestInitialize]
        public void TestSetup()
        {
            gridShapeProcessor = new GridTriangleProcessor();
        }

        [TestMethod]
        public void GetShapeBoundaryTest_00()
        {
            //GridCellPosition gridPos = new GridCellPosition();
            Assert.Fail();
        }


        [TestCleanup]
        public void TestCleanup()
        {
            gridShapeProcessor = null;
        }
    }
}
