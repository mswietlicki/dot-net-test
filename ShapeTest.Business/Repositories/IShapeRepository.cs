﻿using System.Collections.Generic;
using ShapeTest.Business.Entities;

namespace ShapeTest.Business.Repositories
{
    public interface IShapeRepository
    {
        event TriangleAddedEventHandler TriangleAdded;

        List<Shape> GetShapes();

        void AddTriangle(Triangle triangle);

        bool RemoveTriangle(Triangle triangle);
    }
}