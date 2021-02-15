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

    [TestClass]
    public class Grid12x6RightAngleTriangleProcessorTests
    {
        private IGridShapeProcessor _gridShapeProcessor;

        [TestInitialize]
        public void TestSetup()
        {
            _gridShapeProcessor = new Grid12x6RightAngleTriangleProcessor();
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

        #region GetGridCellPosition Tests

        [TestMethod]
        public void ValidGetGridCellPosition_Col9_Row3()
        {        
            Triangle triangle = new Triangle(
                        new List<XYCoordinate>() {
                            new XYCoordinate(40, 30),
                            new XYCoordinate(40, 20),
                            new XYCoordinate(50, 30)
                            }
                        );

            GridCellPosition expected = new GridCellPosition(9, 3);

            GridCellPosition actual = _gridShapeProcessor.GetGridCellPosition(triangle);

            Assert.IsTrue(GridCellPositionTestHelper.TestGridCellPositionValues(expected, actual));
        }

        [TestMethod]
        public void ValidGetGridCellPositionBoundary_Col1_Row1()
        {
            Triangle triangle = new Triangle(
                        new List<XYCoordinate>() {
                            new XYCoordinate(0, 10),
                            new XYCoordinate(0, 0),
                            new XYCoordinate(10, 10)
                            }
                        );

            GridCellPosition expected = new GridCellPosition(1, 1);

            GridCellPosition actual = _gridShapeProcessor.GetGridCellPosition(triangle);

            Assert.IsTrue(GridCellPositionTestHelper.TestGridCellPositionValues(expected, actual));
        }

        [TestMethod]
        public void ValidGetGridCellPositionBoundary_Col12_Row1()
        {         
            Triangle triangle = new Triangle(
                        new List<XYCoordinate>() {
                            new XYCoordinate(60, 0),
                            new XYCoordinate(60, 10),
                            new XYCoordinate(50, 0)
                            }
                        );

            GridCellPosition expected = new GridCellPosition(12, 1);

            GridCellPosition actual = _gridShapeProcessor.GetGridCellPosition(triangle);

            Assert.IsTrue(GridCellPositionTestHelper.TestGridCellPositionValues(expected, actual));
        }

        [TestMethod]
        public void ValidGetGridCellPositionBoundary_Col1_Row6()
        {
            Triangle triangle = new Triangle(
                        new List<XYCoordinate>() {
                            new XYCoordinate(0, 60),
                            new XYCoordinate(0, 50),
                            new XYCoordinate(10, 60)
                            }
                        );

            GridCellPosition expected = new GridCellPosition(1, 6);

            GridCellPosition actual = _gridShapeProcessor.GetGridCellPosition(triangle);

            Assert.IsTrue(GridCellPositionTestHelper.TestGridCellPositionValues(expected, actual));
        }

        [TestMethod]
        public void ValidGetGridCellPositionBoundary_Col12_Row6()
        {
            Triangle triangle = new Triangle(
                        new List<XYCoordinate>() {
                            new XYCoordinate(60, 50),
                            new XYCoordinate(60, 60),
                            new XYCoordinate(50, 50)
                            }
                        );

            GridCellPosition expected = new GridCellPosition(12, 6);

            GridCellPosition actual = _gridShapeProcessor.GetGridCellPosition(triangle);

            Assert.IsTrue(GridCellPositionTestHelper.TestGridCellPositionValues(expected, actual));
        }

        [TestMethod]
        public void InvalidGetGridCellPositionOutsideBoundaryTest_Col13_Row6()
        {
            Triangle triangle = new Triangle(
            new List<XYCoordinate>() {
                            new XYCoordinate(60, 10),
                            new XYCoordinate(60, 0),
                            new XYCoordinate(70, 10)
                }
            );

            GridCellPosition actual;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
               actual = _gridShapeProcessor.GetGridCellPosition(triangle)
            );
        }

        [TestMethod]
        public void InvalidGetGridCellPositionOutsideBoundaryTest_Col12_Row7()
        {
            Triangle triangle = new Triangle(
            new List<XYCoordinate>() {
                            new XYCoordinate(60, 60),
                            new XYCoordinate(60, 70),
                            new XYCoordinate(50, 60)
                }
            );

            GridCellPosition actual;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
               actual = _gridShapeProcessor.GetGridCellPosition(triangle)
            );
        }


        [TestMethod]
        public void InvalidGetGridCellPositionSmallTriangleTest_Col3_Row3()
        {
            Triangle triangle = new Triangle(
            new List<XYCoordinate>() {
                            new XYCoordinate(10, 30),
                            new XYCoordinate(10, 25),
                            new XYCoordinate(15, 30)
                }
            );

            GridCellPosition actual;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
               actual = _gridShapeProcessor.GetGridCellPosition(triangle)
            );
        }


        [TestMethod]
        public void InvalidGetGridCellPositionLargeTriangleTest_Col3_Row3()
        {
            Triangle triangle = new Triangle(
            new List<XYCoordinate>() {
                            new XYCoordinate(10, 30),
                            new XYCoordinate(10, 15),
                            new XYCoordinate(25, 30)
                }
            );

            GridCellPosition actual;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
               actual = _gridShapeProcessor.GetGridCellPosition(triangle)
            );
        }

        [TestMethod]
        public void InvalidGetGridCellPositionObliqueTriangleTest_Col3_Row3()
        {
            Triangle triangle = new Triangle(
            new List<XYCoordinate>() {
                            new XYCoordinate(10, 30),
                            new XYCoordinate(20, 20),
                            new XYCoordinate(30, 30)
                }
            );

            GridCellPosition actual;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
               actual = _gridShapeProcessor.GetGridCellPosition(triangle)
            );
        }


        #endregion

    }
}
