using System.Collections.Generic;
using System.Linq;
using ShapeTest.Business.Entities;

namespace ShapeTest.Business.Repositories
{
    public class ShapeRepository : IShapeRepository
    {
        private readonly List<Triangle> _Triangles; 

        public ShapeRepository()
        {
            _Triangles = new List<Triangle>
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

        public event TriangleAddedEventHandler TriangleAdded;

        public List<Shape> GetShapes()
        {
            return _Triangles.Cast<Shape>().ToList();
        }

        public void AddTriangle(Triangle triangle)
        {
            _Triangles.Add(triangle);
            OnTriangleAdded(triangle);
        }

        public bool RemoveTriangle(Triangle triangle)
        {
            return _Triangles.Remove(triangle);
        }

        protected void OnTriangleAdded(Triangle triangle)
        {
            TriangleAddedEventHandler handler = TriangleAdded;
            handler?.Invoke(this, new TriangleEventArgs(triangle));
        }
    }
}
