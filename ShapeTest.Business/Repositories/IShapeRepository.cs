using System.Collections.Generic;
using ShapeTest.Business.Entities;

namespace ShapeTest.Business.Repositories
{
    public interface IShapeRepository
    {
        event TriangleAddedEventHandler TriangleAdded;

        List<Shape> GetShapes();

        void AddShape(Shape shape);

        bool RemoveTriangle(Triangle triangle);
    }
}
