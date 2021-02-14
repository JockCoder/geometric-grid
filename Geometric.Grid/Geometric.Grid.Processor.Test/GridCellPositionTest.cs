using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometric.Grid.Processor.Grids;
using System;

namespace Geometric.Grid.Processor.Test
{
    [TestClass]
    public class GridCellPositionTest
    {

        [TestMethod]
        public void TestGridProperties()
        {
            int Row = 4;
            int Column = 7;

            GridCellPosition testPosition = new GridCellPosition(Column, Row);

            Assert.AreEqual(Row, testPosition.Row);
            Assert.AreEqual(Column, testPosition.Column);
        }

        [TestMethod]
        public void TestGridZero()
        {
            int Row = 0;
            int Column = 0;

            GridCellPosition testPosition = new GridCellPosition(Column, Row);

            Assert.AreEqual(Row, testPosition.Row);
            Assert.AreEqual(Column, testPosition.Column);
        }

        [TestMethod]
        public void TestNegativeRow()
        {
            int Row = -1;
            int Column = 7;

            GridCellPosition testPosition;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                testPosition = new GridCellPosition(Column, Row)
            );
        }

        [TestMethod]
        public void TestNegativeColumn()
        {
            int Row = 4;
            int Column = -1;

            GridCellPosition testPosition;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                testPosition = new GridCellPosition(Column, Row)
            );
        }


    }
}
