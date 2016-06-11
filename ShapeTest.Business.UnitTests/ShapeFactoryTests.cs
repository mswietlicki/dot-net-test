using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeTest.Business.Entities;
using ShapeTest.Business.Repositories;

namespace ShapeTest.Business.UnitTests
{
    [TestClass]
    public class ShapeFactoryTests
    {
        [TestMethod]
        public void ShouldReturnAllPossibleShapeTypes()
        {
            var expectedShapes = new List<string> 
            {
                "Triangle",
                "Circle",
                "Rectangle",
                "Square"
            };

            var shapeFactory = new ShapeFactory();

            var shapes = shapeFactory.GetShapeTypes();
            CollectionAssert.AreEqual(expectedShapes, shapes.ToList());
        }

        [TestMethod]
        public void ShouldCreateTriangleByName()
        {
            var expectedShapeType = typeof(Triangle);
            var shapeType = "Triangle";

            var shapeFactory = new ShapeFactory();

            var shape = shapeFactory.Create(shapeType);

            Assert.AreSame(expectedShapeType, shape.GetType());
        }

        [TestMethod]
        public void ShouldCreateCircleByName()
        {
            var expectedShapeType = typeof(Circle);
            var shapeType = "Circle";

            var shapeFactory = new ShapeFactory();

            var shape = shapeFactory.Create(shapeType);

            Assert.AreSame(expectedShapeType, shape.GetType());
        }

        [TestMethod]
        public void ShouldCreateSquareByName()
        {
            var expectedShapeType = typeof(Square);
            var shapeType = "Square";

            var shapeFactory = new ShapeFactory();

            var shape = shapeFactory.Create(shapeType);

            Assert.AreSame(expectedShapeType, shape.GetType());
        }

        [TestMethod]
        public void ShouldCreateRectangleByName()
        {
            var expectedShapeType = typeof(Rectangle);
            var shapeType = "Rectangle";

            var shapeFactory = new ShapeFactory();

            var shape = shapeFactory.Create(shapeType);

            Assert.AreSame(expectedShapeType, shape.GetType());
        }
    }
}