using System.ComponentModel;
using PropertyChanged;

namespace ShapeTest.Business.Entities
{
    [ImplementPropertyChanged]
    public class Triangle : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }
        
        public override double GetArea()
        {
            return 0.5 * Base * Height;
        }
    }
}
