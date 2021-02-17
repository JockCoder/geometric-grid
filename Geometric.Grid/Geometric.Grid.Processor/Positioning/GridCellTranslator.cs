using System;
using System.Collections.Generic;
using System.Text;

using Geometric.Grid.Processor.Interfaces;

namespace Geometric.Grid.Processor.Positioning
{
    public class GridCellTranslator: IGridCellPositionConvertor
    {
        public string Row { get; set; }
        public int Column { get; set; }

        /// <summary>
        /// Use this to set to the mapping values
        /// which may be numeric or other.
        /// </summary>
        /// <param name="numericRow"></param>
        /// <param name="numericColumn"></param>
        public void SetGridMappedValues(int numericRow, int numericColumn)
        {
            Column = numericColumn;
            Row = SetMappedRow(numericRow);
        }

        private string SetMappedRow(int numericRow)
        {
            switch (numericRow)
            {
                case 1: return "A";
                case 2: return "B";
                case 3: return "C";
                case 4: return "D";
                case 5: return "E";
                case 6: return "F";
            }

            //we got here, so not a valid value
            throw new ArgumentOutOfRangeException();
        }

        public int GetNumericColumn()
        {
            return Column;
        }

        public int GetNumericRow()
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
