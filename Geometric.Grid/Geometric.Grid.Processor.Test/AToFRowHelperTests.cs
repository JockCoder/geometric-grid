using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometric.Grid.Processor.Interfaces;
using Geometric.Grid.Processor.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geometric.Grid.Processor.Test
{
    [TestClass()]
    public class AToFRowHelperTests
    {
        private IAlphaToNumericRowHelper _helper;

        [TestInitialize]
        public void TestSetup()
        {
            _helper = new AToFRowHelper();
        }

        [TestMethod()]
        public void ValidGetRowA()
        {
            int Row = _helper.GetRow("A");

            Assert.IsTrue(Row == 1);
        }


        [TestMethod()]
        public void ValidGetRowD()
        {
            int Row = _helper.GetRow("D");

            Assert.IsTrue(Row == 4);
        }

        [TestMethod()]
        public void ValidGetRowF()
        {
            int Row = _helper.GetRow("F");

            Assert.IsTrue(Row == 6);
        }

        [TestMethod()]
        public void InvalidGetRowG()
        {
            int Row;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                Row = _helper.GetRow("G")
            );
        }

        [TestMethod()]
        public void InvalidGetRowa()
        {
            int Row;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                Row = _helper.GetRow("a")
            );
        }


        [TestMethod()]
        public void InvalidGetRow1()
        {
            int Row;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                Row = _helper.GetRow("1")
            );
        }

        [TestMethod()]
        public void InvalidGetRowAA()
        {
            int Row;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                Row = _helper.GetRow("AA")
            );
        }
    }
}