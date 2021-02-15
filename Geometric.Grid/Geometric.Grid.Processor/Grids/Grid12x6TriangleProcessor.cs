using Geometric.Grid.Processor.Interfaces;
using Geometric.Grid.Processor.Shapes.Math;
using Geometric.Grid.Processor.Shapes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geometric.Grid.Processor.Grids
{
    public class Grid12x6TriangleProcessor : IGridShapeProcessor
    {
        private const int MIN_COLUMN_LENGTH = 1;
        private const int MAX_COLUMN_LENGTH = 12;
        private const int MIN_ROW_HEIGHT = 1;
        private const int MAX_ROW_HEIGHT = 6;


        private const int TRIANGLE_LEG_SIZE = 10;

        public GridCellPosition GetGridCellPosition(Shape shape)
        {
            throw new NotImplementedException();
        }

        public IShape GetShape(GridCellPosition gridCellPosition)
        {
            if(!ValidateGridCellPosition(gridCellPosition))
            {
                throw new ArgumentOutOfRangeException();
            }

            return GetTriangleFromPosition(gridCellPosition);
        }

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

        public bool ValidateShape(Shape shape)
        {
            throw new NotImplementedException();
        }

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

        #endregion
    }
}
