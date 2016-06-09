using System.ComponentModel;
using PropertyChanged;

namespace ShapeTest.Business.Entities
{
    [ImplementPropertyChanged]
    public class Rectangle : Shape
    {
        public override event PropertyChangedEventHandler PropertyChanged;
        public double Height { get; set; }
        public double Width { get; set; }

        public override double GetArea()
        {
            return Height * Width;
        }
    }
}