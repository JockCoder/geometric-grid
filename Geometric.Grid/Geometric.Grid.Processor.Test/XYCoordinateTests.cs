﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Geometric.Grid.Processor.Positioning;

namespace Geometric.Grid.Processor.Test
{
    [TestClass]
    public class XYCoordinateTests
    {
        [TestMethod]
        public void ValidTestXYProperties()
        {
            int XCoord = 5;
            int YCoord = 2;

            XYCoordinate coords = new XYCoordinate(XCoord, YCoord);

            Assert.AreEqual(XCoord, coords.X);
            Assert.AreEqual(YCoord, coords.Y);
        }

        [TestMethod]
        public void ValidTestXYZero()
        {
            int XCoord = 0;
            int YCoord = 0;

            XYCoordinate coords = new XYCoordinate(XCoord, YCoord);

            Assert.AreEqual(XCoord, coords.X);
            Assert.AreEqual(YCoord, coords.Y);
        }

        [TestMethod]
        public void InvalidTestNegativeX()
        {
            int XCoord = -1;
            int YCoord = 2;

            XYCoordinate coords;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                coords = new XYCoordinate(XCoord, YCoord)
            );
        }

        [TestMethod]
        public void InvalidTestNegativeY()
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
