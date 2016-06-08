﻿namespace ShapeTest.Business.Entities
{
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