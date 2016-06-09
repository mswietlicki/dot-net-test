using System.ComponentModel;
using PropertyChanged;

namespace ShapeTest.Business.Entities
{
    [ImplementPropertyChanged]
    public class Square : Shape
    {
        public double Lenght { get; set; }
        public override double GetArea()
        {
            return Lenght * Lenght;
        }
    }
}