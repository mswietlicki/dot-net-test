using System;

namespace ShapeTest.Business.Entities
{
    public class Circle : Shape
    {
        public double Radius { get; set; }
        public override double GetArea()
        {
            return Radius * Radius * Math.PI;
        }
    }
}