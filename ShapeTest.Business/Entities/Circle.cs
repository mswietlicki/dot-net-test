using System;
using System.ComponentModel;
using PropertyChanged;

namespace ShapeTest.Business.Entities
{
    [ImplementPropertyChanged]
    public class Circle : Shape
    {
        public double Radius { get; set; }
        public override double GetArea()
        {
            return Radius * Radius * Math.PI;
        }
    }
}