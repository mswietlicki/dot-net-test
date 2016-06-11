using System;
using System.Collections.Generic;
using ShapeTest.Business.Entities;

namespace ShapeTest.Business.Repositories
{
    public interface IShapeRepository
    {
        event ShapeAddedEventHandler ShapeAdded;
        
        List<Shape> GetShapes();
        void AddShape(Shape shape);
        bool RemoveShape(Shape shape);
    }
}
