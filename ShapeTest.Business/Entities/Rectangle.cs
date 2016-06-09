using System.ComponentModel;
using PropertyChanged;

namespace ShapeTest.Business.Entities
{
    [ImplementPropertyChanged]
    public class Rectangle : Shape
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public override double GetArea()
        {
            return Height * Width;
        }
    }
}