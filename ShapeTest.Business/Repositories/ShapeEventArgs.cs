using System;
using ShapeTest.Business.Entities;

namespace ShapeTest.Business.Repositories
{
    public class ShapeEventArgs : EventArgs
    {
        public ShapeEventArgs(Shape shape)
        {
            Shape = shape;
        }

        public Shape Shape { get; }
    }
}
