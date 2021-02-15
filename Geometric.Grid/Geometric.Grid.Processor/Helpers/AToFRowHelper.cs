using Geometric.Grid.Processor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geometric.Grid.Processor.Helpers
{
    public class AToFRowHelper: IAlphaToNumericRowHelper
    {
        public int GetRow(string alphaRow)
        {
            if(alphaRow.Length > 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            switch (alphaRow)
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
