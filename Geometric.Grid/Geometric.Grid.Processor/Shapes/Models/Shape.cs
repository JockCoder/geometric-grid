using Geometric.Grid.Processor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geometric.Grid.Processor.Shapes.Models
{
    public class Shape: IShape
    {
        public string Name { get; }

        public Shape(string name)
        {
            Name = name;
        }

    }
}
