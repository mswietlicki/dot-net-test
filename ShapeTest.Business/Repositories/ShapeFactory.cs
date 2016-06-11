using System;
using System.Collections.Generic;
using System.Linq;
using ShapeTest.Business.Entities;

namespace ShapeTest.Business.Repositories
{
    public class ShapeFactory : IShapeFactory
    {
        private readonly List<Type> _ShapeTypes;

        public ShapeFactory()
        {
            _ShapeTypes = new List<Type> 
            {
                typeof(Triangle),
                typeof(Circle),
                typeof(Rectangle),
                typeof(Square),
            };
        }

        public Shape Create(string shapeType)
        {
            var type = _ShapeTypes.FirstOrDefault(_ => _.Name == shapeType);
            var shape = Activator.CreateInstance(type) as Shape;
            shape.Name = shapeType;

            return shape;
        }
        
        public IEnumerable<string> GetShapeTypes()
        {
            return _ShapeTypes.Select(_ => _.Name);
        }
    }
}