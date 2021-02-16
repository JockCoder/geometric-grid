using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Geometric.Grid.Processor.Positioning;
using Geometric.Grid.Processor.Shapes.Models;

using Geometric.Grid.Processor.Test.TestHelpers;

namespace Geometric.Grid.Processor.Test
{
    [TestClass]
    public class TriangleTests
    {

        [TestMethod]
        public void ValidTestTriangleVertices()
        {
            XYCoordinate Vertex1 = new XYCoordinate(1, 1);
            XYCoordinate Vertex2 = new XYCoordinate(1, 2);
            XYCoordinate Vertex3 = new XYCoordinate(2, 1);

            Triangle triangle = new Triangle(
                new List<XYCoordinate>() { 
                    Vertex1, 
                    Vertex2, 
                    Vertex3 }
                );

            Assert.AreEqual("Triangle", triangle.Name);
            Assert.AreEqual(3, triangle.Vertices.Count);
            Assert.IsTrue(XYCoordinateTestHelper.TestXYCoordinateValues(Vertex1, triangle.Vertices[0]));
            Assert.IsTrue(XYCoordinateTestHelper.TestXYCoordinateValues(Vertex2, triangle.Vertices[1]));
            Assert.IsTrue(XYCoordinateTestHelper.TestXYCoordinateValues(Vertex3, triangle.Vertices[2]));
        }

        [TestMethod]
        public void InvalidTestWithNullVertices()
        {
            Triangle triangle;

            Assert.ThrowsException<ArgumentNullException>(() =>
                    triangle = new Triangle(null)
            );
        }

        [TestMethod]
        public void InvalidTestWithZeroVertices()
        {
            Triangle triangle;

            Assert.ThrowsException<ArgumentException>(() =>
                    triangle = new Triangle(new List<XYCoordinate>())
            );
        }

        [TestMethod]
        public void InvalidTestWithTwoVertices()
        {
            XYCoordinate Vertex1 = new XYCoordinate(1, 1);
            XYCoordinate Vertex2 = new XYCoordinate(1, 2);

            Triangle triangle;

            Assert.ThrowsException<ArgumentException>(() =>
                    triangle = new Triangle(
                        new List<XYCoordinate>() {
                            Vertex1,
                            Vertex2 }
                        )
            );
        }

        [TestMethod]
        public void InvalidTestWithFourVertices()
        {
            XYCoordinate Vertex1 = new XYCoordinate(1, 1);
            XYCoordinate Vertex2 = new XYCoordinate(1, 2);
            XYCoordinate Vertex3 = new XYCoordinate(2, 2);
            XYCoordinate Vertex4 = new XYCoordinate(2, 1);

            Triangle triangle;

            Assert.ThrowsException<ArgumentException>(() =>
                    triangle = new Triangle(
                        new List<XYCoordinate>() {
                            Vertex1,
                            Vertex2,
                            Vertex3,
                            Vertex4}
                        )
            );
        }



    }
}
