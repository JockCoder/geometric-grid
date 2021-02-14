using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometric.Grid.Processor.Shapes.Math;
using Geometric.Grid.Processor.Shapes.Models;
using System.Collections.Generic;

namespace Geometric.Grid.Processor.Test
{
    [TestClass]
    public class TriangleTest
    {

        [TestMethod]
        public void TestValidTriangleVertices()
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
            Assert.AreEqual<XYCoordinate>(Vertex1, triangle.Vertices[0]);
            Assert.AreEqual<XYCoordinate>(Vertex2, triangle.Vertices[1]);
            Assert.AreEqual<XYCoordinate>(Vertex3, triangle.Vertices[2]);
        }

        [TestMethod]
        public void TestWithNullVertices()
        {
            Triangle triangle;

            Assert.ThrowsException<ArgumentNullException>(() =>
                    triangle = new Triangle(null)
            );
        }

        [TestMethod]
        public void TestWithZeroVertices()
        {
            Triangle triangle;

            Assert.ThrowsException<ArgumentException>(() =>
                    triangle = new Triangle(new List<XYCoordinate>())
            );
        }

        [TestMethod]
        public void TestWithTwoVertices()
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
        public void TestWithFourVertices()
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
