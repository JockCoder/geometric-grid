using Geometric.Grid.Processor.Interfaces;

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
