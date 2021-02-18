using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using Geometric.Grid.Processor.Positioning;


namespace Geometric.Grid.Processor.Test
{
    [TestClass()]
    public class GridCellMapperTests
    {
        private GridCellMapper _gridCellMapper;

        [TestInitialize]
        public void TestSetup()
        {
            _gridCellMapper = new GridCellMapper();
        }

        [TestMethod()]
        public void TestValidGridNumericValuesFor_A_1()
        {
            _gridCellMapper.Row = "A";
            _gridCellMapper.Column = 1;

            Assert.AreEqual(1, _gridCellMapper.GetNumericRow());
            Assert.AreEqual(1, _gridCellMapper.GetNumericColumn());
        }

        [TestMethod()]
        public void TestValidGridNumericValuesFor_A_12()
        {
            _gridCellMapper.Row = "A";
            _gridCellMapper.Column = 12;

            Assert.AreEqual(1, _gridCellMapper.GetNumericRow());
            Assert.AreEqual(12, _gridCellMapper.GetNumericColumn());
        }

        [TestMethod()]
        public void TestValidGridNumericValuesFor_F_1()
        {
            _gridCellMapper.Row = "F";
            _gridCellMapper.Column = 1;

            Assert.AreEqual(6, _gridCellMapper.GetNumericRow());
            Assert.AreEqual(1, _gridCellMapper.GetNumericColumn());
        }

        [TestMethod()]
        public void TestValidGridNumericValuesFor_F_12()
        {
            _gridCellMapper.Row = "F";
            _gridCellMapper.Column = 12;

            Assert.AreEqual(6, _gridCellMapper.GetNumericRow());
            Assert.AreEqual(12, _gridCellMapper.GetNumericColumn());
        }


        [TestMethod()]
        public void TestValidGridNumericValuesFor_C_7()
        {
            _gridCellMapper.Row = "C";
            _gridCellMapper.Column = 7;

            Assert.AreEqual(3, _gridCellMapper.GetNumericRow());
            Assert.AreEqual(7, _gridCellMapper.GetNumericColumn());
        }

        [TestMethod()]
        public void TestInvalidGridNumericValuesFor_RowG()
        {
            _gridCellMapper.Row = "G";

            int row;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                row = _gridCellMapper.GetNumericRow()
            );
        }

        [TestMethod()]
        public void TestInvalidGridNumericValuesFor_Column13()
        {
            _gridCellMapper.Column = 13;

            int column;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                column = _gridCellMapper.GetNumericColumn()
            );
        }


        [TestMethod()]
        public void TestValidGridMappedValuesFor_A_1()
        {
            _gridCellMapper.SetGridMappedValues(1, 1);

            Assert.AreEqual("A", _gridCellMapper.Row);
            Assert.AreEqual(1, _gridCellMapper.Column);
        }

        [TestMethod()]
        public void TestValidGridMappedValuesFor_A_12()
        {
            _gridCellMapper.SetGridMappedValues(1, 12);

            Assert.AreEqual("A", _gridCellMapper.Row);
            Assert.AreEqual(12, _gridCellMapper.Column);
        }

        [TestMethod()]
        public void TestValidGridMappedValuesFor_F_1()
        {
            _gridCellMapper.SetGridMappedValues(6, 1);

            Assert.AreEqual("F", _gridCellMapper.Row);
            Assert.AreEqual(1, _gridCellMapper.Column);
        }

        [TestMethod()]
        public void TestValidGridMappedValuesFor_F_12()
        {
            _gridCellMapper.SetGridMappedValues(6, 12);

            Assert.AreEqual("F", _gridCellMapper.Row);
            Assert.AreEqual(12, _gridCellMapper.Column);
        }


        [TestMethod()]
        public void TestValidGridMappedValuesFor_C_7()
        {
            _gridCellMapper.SetGridMappedValues(3, 7);

            Assert.AreEqual("C", _gridCellMapper.Row);
            Assert.AreEqual(7, _gridCellMapper.Column);
        }

        [TestMethod()]
        public void TestInvalidGridMappedValuesFor_G_1()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                _gridCellMapper.SetGridMappedValues(7, 1)
            );
        }

        [TestMethod()]
        public void TestInvalidGridMappedValuesFor_A_13()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                _gridCellMapper.SetGridMappedValues(1, 13)
            );
        }


    }
}