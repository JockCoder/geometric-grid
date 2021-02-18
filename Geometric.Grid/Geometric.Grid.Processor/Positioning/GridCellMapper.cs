using System;
using System.Collections.Generic;
using System.Text;

using Geometric.Grid.Processor.Interfaces;

namespace Geometric.Grid.Processor.Positioning
{
    public class GridCellMapper
    {
        public string Row { get; set; }
        public int Column { get; set; }

        private readonly string _alphaRow = "ABCDEF";
        private const int MAX_COLUMN_LENGTH = 12;


        /// <summary>
        /// Use this to set to the mapping values
        /// which may be numeric or other.
        /// </summary>
        /// <param name="numericRow"></param>
        /// <param name="numericColumn"></param>
        public void SetGridMappedValues(int numericRow, int numericColumn)
        {
            Column = setMappedColumn(numericColumn);
            Row = SetMappedRow(numericRow);
        }

        private string SetMappedRow(int numericRow)
        {
            if(numericRow > _alphaRow.Length)
            {
                //we got here, so not a valid value
                throw new ArgumentOutOfRangeException();
            }
            
            //rem string chars are base 0, so take away 1.
            return _alphaRow.Substring(numericRow - 1, 1);
        }

        private int setMappedColumn(int numericColumn)
        {
            if(numericColumn < 0 || numericColumn > MAX_COLUMN_LENGTH)
            {
                throw new ArgumentOutOfRangeException();
            }

            return numericColumn;
        }


        /// <summary>
        /// These methods should convert from mapping values
        /// to a numeric grid
        /// </summary>
        /// <returns></returns>
        public int GetNumericColumn()
        {
            if (Column < 0 || Column > MAX_COLUMN_LENGTH)
            {
                throw new ArgumentOutOfRangeException();
            }

            return Column;
        }

        public int GetNumericRow()
        {
            //We're only dealing with single chars for this grid mapping
            if (Row.Length > 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            int index = _alphaRow.IndexOf(Row);

            //Didn't find it - throw our hands up
            if(index == -1)
            {
                throw new ArgumentOutOfRangeException();
            }

            //Rem string is zero based, so add 1
            return index + 1;
        }
    }
}
