using System;
using System.Collections.Generic;
using System.Text;

using Geometric.Grid.Processor.Interfaces;

namespace Geometric.Grid.Processor.Positioning
{
    public class GridCellTranslator : IGridCellPositionConvertor
    {
        public string Row { get; set; }
        public int Column { get; set; }

        public int GetColumn()
        {
            return Column;
        }

        public int GetRow()
        {
            if (Row.Length > 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            switch (Row)
            {
                case "A": return 1;
                case "B": return 2;
                case "C": return 3;
                case "D": return 4;
                case "E": return 5;
                case "F": return 6;
            }

            //we got here, so not a valid value
            throw new ArgumentOutOfRangeException();
        }
    }
}
