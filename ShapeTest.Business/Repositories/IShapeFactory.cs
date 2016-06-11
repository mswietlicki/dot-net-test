using System;
using System.Collections.Generic;
using System.Threading;
using ShapeTest.Business.Entities;

namespace ShapeTest.Business.Repositories
{
    public interface IShapeFactory
    {
        Shape Create(string shapeType);
        IEnumerable<string> GetShapeTypes();
    }
}