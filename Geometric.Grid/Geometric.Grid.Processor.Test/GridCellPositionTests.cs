using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using Geometric.Grid.Processor.Positioning;

namespace Geometric.Grid.Processor.Test
{
    [TestClass]
    public class GridCellPositionTests
    {

        [TestMethod]
        public void ValidTestGridProperties()
        {
            int Row = 4;
            int Column = 7;

            GridCellPosition testPosition = new GridCellPosition(Column, Row);

            Assert.AreEqual(Row, testPosition.Row);
            Assert.AreEqual(Column, testPosition.Column);
        }

        [TestMethod]
        public void ValidTestGridCellOne()
        {
            int Row = 1;
            int Column = 1;

            GridCellPosition testPosition = new GridCellPosition(Column, Row);

            Assert.AreEqual(Row, testPosition.Row);
            Assert.AreEqual(Column, testPosition.Column);
        }

        [TestMethod]
        public void InvalidTestGridZero()
        {
            int Row = 0;
            int Column = 0;

            GridCellPosition testPosition;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                testPosition = new GridCellPosition(Column, Row)
            );
        }

        [TestMethod]
        public void InvalidTestNegativeRow()
        {
            int Row = -1;
            int Column = 7;

            GridCellPosition testPosition;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                testPosition = new GridCellPosition(Column, Row)
            );
        }

        [TestMethod]
        public void InvalidTestNegativeColumn()
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
