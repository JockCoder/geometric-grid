using System;
using System.Collections.Generic;
using System.Text;

namespace Geometric.Grid.Processor.Shapes.Models
{
    public class Shape
    {
        public string Name { get; private set; }

        public Shape(string name)
        {
            Name = name;
        }

    }
}
