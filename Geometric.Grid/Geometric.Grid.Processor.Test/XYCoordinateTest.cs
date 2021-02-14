using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometric.Grid.Processor.Shapes.Math;

namespace Geometric.Grid.Processor.Test
{
    [TestClass]
    public class XYCoordinateTest
    {
        [TestMethod]
        public void TestXYProperties()
        {
            int XCoord = 5;
            int YCoord = 2;

            XYCoordinate coords = new XYCoordinate(XCoord, YCoord);

            Assert.AreEqual(XCoord, coords.X);
            Assert.AreEqual(YCoord, coords.Y);
        }

        [TestMethod]
        public void TestXYZero()
        {
            int XCoord = 0;
            int YCoord = 0;

            XYCoordinate coords = new XYCoordinate(XCoord, YCoord);

            Assert.AreEqual(XCoord, coords.X);
            Assert.AreEqual(YCoord, coords.Y);
        }

        [TestMethod]
        public void TestNegativeX()
        {
            int XCoord = -1;
            int YCoord = 2;

            XYCoordinate coords;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                coords = new XYCoordinate(XCoord, YCoord)
            );
        }

        [TestMethod]
        public void TestNegativeY()
        {
            int XCoord = 5;
            int YCoord = -1;

            XYCoordinate coords;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                coords = new XYCoordinate(XCoord, YCoord)
            );
        }
    }
}
