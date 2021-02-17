using System;
using System.Collections.Generic;
using System.Text;

namespace Geometric.Grid.Processor.Interfaces
{
    public interface IGridCellPositionConvertor
    {
        int GetRow();
        int GetColumn();
    }
}
