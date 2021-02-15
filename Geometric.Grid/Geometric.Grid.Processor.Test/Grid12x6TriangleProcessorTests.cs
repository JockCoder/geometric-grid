using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometric.Grid.Processor.Interfaces;
using Geometric.Grid.Processor.Grids;
using Geometric.Grid.Processor.Shapes.Math;
using Geometric.Grid.Processor.Shapes.Models;
using System.Collections.Generic;
using System;
using Geometric.Grid.Processor.Test.TestHelpers;

namespace Geometric.Grid.Processor.Test
{
    /// <summary>
    /// Remember: Arrange, Act, Assert!
    /// </summary>
    [TestClass]
    public class Grid12x6TriangleProcessorTests
    {
        private IGridShapeProcessor _gridShapeProcessor;

        [TestInitialize]
        public void TestSetup()
        {
            _gridShapeProcessor = new Grid12x6TriangleProcessor();
        }

        #region GetShape Tests


        [TestMethod]
        public void ValidGetShapeTest_Col9_Row3()
        {
            GridCellPosition gridPos = new GridCellPosition(9, 3);

            Triangle expected = new Triangle(
                        new List<XYCoordinate>() {
                            new XYCoordinate(40, 30),
                            new XYCoordinate(40, 20),
                            new XYCoordinate(50, 30)
                            }
                        );

            Triangle actual = (Triangle)_gridShapeProcessor.GetShape(gridPos);

            Assert.IsTrue(TriangleTestHelper.TestTriangleValues(expected, actual));
        }

        [TestMethod]
        public void ValidGetShapeBoundaryTest_Col1_Row1()
        {
            GridCellPosition gridPos = new GridCellPosition(1,1);

            Triangle expected = new Triangle(
                        new List<XYCoordinate>() {
                            new XYCoordinate(0, 10),
                            new XYCoordinate(0, 0),
                            new XYCoordinate(10, 10)
                            }
                        );

            Triangle actual = (Triangle)_gridShapeProcessor.GetShape(gridPos);

            Assert.IsTrue(TriangleTestHelper.TestTriangleValues(expected, actual));
        }

        [TestMethod]
        public void ValidGetShapeBoundaryTest_Col12_Row1()
        {
            GridCellPosition gridPos = new GridCellPosition(12, 1);

            Triangle expected = new Triangle(
                        new List<XYCoordinate>() {
                            new XYCoordinate(60, 0),
                            new XYCoordinate(60, 10),
                            new XYCoordinate(50, 0)
                            }
                        );

            Triangle actual = (Triangle)_gridShapeProcessor.GetShape(gridPos);

            Assert.IsTrue(TriangleTestHelper.TestTriangleValues(expected, actual));
        }

        [TestMethod]
        public void ValidGetShapeBoundaryTest_Col1_Row6()
        {
            GridCellPosition gridPos = new GridCellPosition(1, 6);

            Triangle expected = new Triangle(
                        new List<XYCoordinate>() {
                            new XYCoordinate(0, 60),
                            new XYCoordinate(0, 50),
                            new XYCoordinate(10, 60)
                            }
                        );

            Triangle actual = (Triangle)_gridShapeProcessor.GetShape(gridPos);

            Assert.IsTrue(TriangleTestHelper.TestTriangleValues(expected, actual));
        }

        [TestMethod]
        public void ValidGetShapeBoundaryTest_Col12_Row6()
        {
            GridCellPosition gridPos = new GridCellPosition(12, 6);

            Triangle expected = new Triangle(
                        new List<XYCoordinate>() {
                            new XYCoordinate(60, 50),
                            new XYCoordinate(60, 60),
                            new XYCoordinate(50, 50)
                            }
                        );

            Triangle actual = (Triangle)_gridShapeProcessor.GetShape(gridPos);

            Assert.IsTrue(TriangleTestHelper.TestTriangleValues(expected, actual));
        }

        [TestMethod]
        public void InvalidGetShapeOutsideBoundaryTest_Col13_Row6()
        {
            GridCellPosition gridPos = new GridCellPosition(13, 6);

            Triangle actual;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
               actual = (Triangle)_gridShapeProcessor.GetShape(gridPos)
            );
        }


        [TestMethod]
        public void InvalidGetShapeOutsideBoundaryTest_Col12_Row7()
        {
            GridCellPosition gridPos = new GridCellPosition(12, 7);

            Triangle actual;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
               actual = (Triangle)_gridShapeProcessor.GetShape(gridPos)
            );
        }

        #endregion

    }
}
