using System;
using System.Collections.Generic;

using Geometric.Grid.Processor.Interfaces;
using Geometric.Grid.Processor.Positioning;
using Geometric.Grid.Processor.Shapes.Models;



namespace Geometric.Grid.Processor.Grids
{
    /// <summary>
    /// This is a 12 x Column x 6 Row Grid, containing
    /// Right Angled Triangle shapes, both upright and inverted.
    /// Both upgright and inverted triangles lie apon each other
    /// creating a square, split diagonally in two.
    /// Uprights are on the odd number columns, Inverts are on
    /// the right number columns
    /// -
    /// The Grid is 60 pixels in length and height
    /// Each leg (non-hypotenuese) of the triangle is 10 pixels.
    /// -
    /// Implements the IGridShapeProcessor, although could really be
    /// implemented as a static class as it has no state.
    /// </summary>
    public class Grid12x6RightAngleTriangleProcessor : IGridShapeProcessor
    {
        #region Constants for this Grid

        private const int MIN_COLUMN_LENGTH = 1;
        private const int MAX_COLUMN_LENGTH = 12;
        private const int MIN_ROW_HEIGHT = 1;
        private const int MAX_ROW_HEIGHT = 6;

        private const int TRIANGLE_LEG_SIZE = 10;

        private const int MAX_CANVAS_LENGTH_PIXELS = 60;
        private const int MAX_CANVAS_HEIGHT_PIXELS = 60;

        #endregion

        #region IGridShapeProcessor Methods

        /// <summary>
        /// Get the shape for the grid position given
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        public GridCellPosition GetGridCellPosition(IShape shape)
        {
            if(!ValidateShape(shape))
            {
                throw new ArgumentOutOfRangeException();
            }

            return GetGridPositionFromShape(shape);
        }

        /// <summary>
        /// For a given shape, get the grid position it's in
        /// </summary>
        /// <param name="gridCellPosition"></param>
        /// <returns></returns>
        public IShape GetShape(GridCellPosition gridCellPosition)
        {
            if(!ValidateGridCellPosition(gridCellPosition))
            {
                throw new ArgumentOutOfRangeException();
            }

            return GetTriangleFromPosition(gridCellPosition);
        }

        /// <summary>
        /// Validate the Grid Position Provided
        /// </summary>
        /// <param name="gridCellPosition"></param>
        /// <returns>true if the grid is valid</returns>
        public bool ValidateGridCellPosition(GridCellPosition gridCellPosition)
        {
            if(gridCellPosition.Column <  MIN_COLUMN_LENGTH ||
                gridCellPosition.Column > MAX_COLUMN_LENGTH ||
                gridCellPosition.Row < MIN_ROW_HEIGHT ||
                gridCellPosition.Row > MAX_ROW_HEIGHT)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validate the shape
        /// </summary>
        /// <param name="shape"></param>
        /// <returns>true if a valid triangle</returns>
        public bool ValidateShape(IShape shape)
        {
            Triangle triangle = (Triangle)shape;

            if( IsWithinCanvasArea(triangle) &&
                IsValidRightAngleTriangle(triangle) &&
                IsValidSizeTriangle(triangle))
            {
                return true;
            }

            return false;
        }

        #endregion

        #region Private Methods

        #region GetShape Methods

        private Triangle GetTriangleFromPosition(GridCellPosition gridCellPosition)
        {
            //if it's an even column it's an inverted right angled triangle,
            //else if it's an odd column it's upright

            if((gridCellPosition.Column % 2) == 0)
            {
                return CreateInvertedRightAngleTriangle(gridCellPosition);
            }

            return CreateUprightRightAngleTriangle(gridCellPosition);            
        }

        private Triangle CreateUprightRightAngleTriangle(GridCellPosition gridCellPosition)
        {
            return CreateTriangle(
                CalculateUprightTriangleVertex1(gridCellPosition),
                CalculateUprightTriangleVertex2(gridCellPosition),
                CalculateUprightTriangleVertex3(gridCellPosition)
                );
        }

        private Triangle CreateInvertedRightAngleTriangle(GridCellPosition gridCellPosition)
        {
            return CreateTriangle(
                CalculateInvertedTriangleVertex1(gridCellPosition),
                CalculateInvertedTriangleVertex2(gridCellPosition),
                CalculateInvertedTriangleVertex3(gridCellPosition)
                );
        }

        private Triangle CreateTriangle(XYCoordinate Vertex1, XYCoordinate Vertex2, XYCoordinate Vertex3)
        {
            return new Triangle(
               new List<XYCoordinate>() {
                    Vertex1,
                    Vertex2,
                    Vertex3 
               }
            );
        }

        #region Upright Triangle Calculations

        private XYCoordinate CalculateUprightTriangleVertex1(GridCellPosition gridCellPosition)
        {
            int x = (gridCellPosition.Column - 1) * 5;
            int y = gridCellPosition.Row * 10;

            return new XYCoordinate(x, y);
        }

        private XYCoordinate CalculateUprightTriangleVertex2(GridCellPosition gridCellPosition)
        {
            int x = (gridCellPosition.Column - 1) * 5;
            int y = (gridCellPosition.Row - 1) * 10;

            return new XYCoordinate(x, y);
        }

        private XYCoordinate CalculateUprightTriangleVertex3(GridCellPosition gridCellPosition)
        {
            int x = (gridCellPosition.Column + 1) * 5;
            int y = gridCellPosition.Row * 10;

            return new XYCoordinate(x, y);
        }

        #endregion


        #region Inverted Triangle Calculations

        private XYCoordinate CalculateInvertedTriangleVertex1(GridCellPosition gridCellPosition)
        {
            int x = gridCellPosition.Column * 5;
            int y = (gridCellPosition.Row - 1) * 10;

            return new XYCoordinate(x, y);
        }

        private XYCoordinate CalculateInvertedTriangleVertex2(GridCellPosition gridCellPosition)
        {
            int x = gridCellPosition.Column * 5;
            int y = gridCellPosition.Row * 10;

            return new XYCoordinate(x, y);
        }

        private XYCoordinate CalculateInvertedTriangleVertex3(GridCellPosition gridCellPosition)
        {
            int x = (gridCellPosition.Column - 2) * 5;
            int y = (gridCellPosition.Row - 1) * 10;

            return new XYCoordinate(x, y);
        }

        #endregion

        #endregion

        #region ValidateShape Methods

        private bool IsTriangleUpright(Triangle triangle)
        {
            //If vertex 1's X Coord is less than Vertex 3's X Coord
            //the triangle is upright
            if (triangle.Vertices[0].X < triangle.Vertices[2].X)
            {
                return true;
            }

            //Must be inverted then
            return false;
        }

        private bool IsWithinCanvasArea(Triangle triangle)
        {
            if(triangle.Vertices[0].X > MAX_CANVAS_LENGTH_PIXELS ||
                triangle.Vertices[1].X > MAX_CANVAS_LENGTH_PIXELS ||
                triangle.Vertices[2].X > MAX_CANVAS_LENGTH_PIXELS ||
                triangle.Vertices[0].Y > MAX_CANVAS_HEIGHT_PIXELS ||
                triangle.Vertices[1].Y > MAX_CANVAS_HEIGHT_PIXELS ||
                triangle.Vertices[2].Y > MAX_CANVAS_HEIGHT_PIXELS)
            {
                return false;
            }

            return true;
        }

        private bool IsValidRightAngleTriangle(Triangle triangle)
        {
            if((triangle.Vertices[0].X == triangle.Vertices[1].X) &&
               (triangle.Vertices[0].Y == triangle.Vertices[2].Y))
            {
                return true;
            }

            return false;
        }

        private bool IsValidSizeTriangle(Triangle triangle)
        {
            if( IsTriangleUpright(triangle) )
            {
                //For the upright Triangle
                //Check the 2 x non-Hypoteneuse Sides are of the correct size
                if((triangle.Vertices[2].X - triangle.Vertices[0].X) == TRIANGLE_LEG_SIZE &&
                   (triangle.Vertices[0].Y - triangle.Vertices[1].Y) == TRIANGLE_LEG_SIZE)
                {
                    return true;
                }
                       
            }
            else 
            {
                //For the inverted Triangle
                //Check the 2 x non-Hypoteneuse Sides are of the correct size
                if ((triangle.Vertices[0].X - triangle.Vertices[2].X) == TRIANGLE_LEG_SIZE &&
                   (triangle.Vertices[1].Y - triangle.Vertices[0].Y) == TRIANGLE_LEG_SIZE)
                {
                    return true;
                }
            }

            //If we got here, it's not the correct size
            return false;
        }

        #endregion

        #region GetGridCellPosition Methods

        private GridCellPosition GetGridPositionFromShape(IShape shape)
        {
            Triangle triangle = (Triangle)shape;

            if (IsTriangleUpright(triangle))
            {
                return CalculateCellPositionFromUprightTriangle(triangle);
            }

            return CalculateCellPositionFromInvertedTriangle(triangle);
        }

        private GridCellPosition CalculateCellPositionFromUprightTriangle(Triangle triangle)
        {
            int column = (triangle.Vertices[2].X / 5) - 1;
            int row = triangle.Vertices[2].Y / 10;

            return new GridCellPosition(column, row);
        }

        private GridCellPosition CalculateCellPositionFromInvertedTriangle(Triangle triangle)
        {
            int column = (triangle.Vertices[2].X / 5) + 2;
            int row = (triangle.Vertices[2].Y / 10) + 1;

            return new GridCellPosition(column, row);
        }


        #endregion

        #endregion
    }
}
