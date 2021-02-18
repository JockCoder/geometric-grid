using System;
using System.Collections.Generic;
using System.Text;

namespace Geometric.Grid.Processor.Interfaces
{
    public interface IGridCellMapper
    {
        /// <summary>
        /// Use this to set to the mapping values
        /// which may be numeric or other.
        /// </summary>
        /// <param name="numericRow"></param>
        /// <param name="numericColumn"></param>
        void SetGridMappedValues(int numericRow, int numericColumn);

        /// <summary>
        /// These methods should convert from mapping values
        /// to a numeric grid
        /// </summary>
        /// <returns></returns>
        int GetNumericRow();
        int GetNumericColumn();
    }
}
