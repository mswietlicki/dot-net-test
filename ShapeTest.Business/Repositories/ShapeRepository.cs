using System;
using System.Collections.Generic;
using System.Linq;
using ShapeTest.Business.Entities;

namespace ShapeTest.Business.Repositories
{
    public class ShapeRepository : IShapeRepository
    {
        private readonly List<Shape> _Shapes; 

        public ShapeRepository()
        {
            _Shapes = new List<Shape>
            {
                new Triangle
                {
                    Name = "Triangle 1",
                    Base = 12.5,
                    Height = 13 
                },
                new Triangle
                {
                    Name = "Triangle 2",
                    Base = 23.4,
                    Height = 14
                },
                new Triangle
                {
                    Name = "Triangle 3",
                    Base = 42,
                    Height = 22
                }
            };
        }

        public event ShapeAddedEventHandler ShapeAdded;

        public List<Shape> GetShapes()
        {
            return _Shapes;
        }

        public void AddShape(Shape shape)
        {
            _Shapes.Add(shape);
            OnShapeAdded(shape);
        }

        public bool RemoveShape(Shape shape)
        {
            return _Shapes.Remove(shape);
        }

        protected void OnShapeAdded(Shape shape)
        {
            var handler = ShapeAdded;
            handler?.Invoke(this, new ShapeEventArgs(shape));
        }
    }
}
