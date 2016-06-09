using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeTest.Business.Entities;
using ShapeTest.Business.Repositories;

namespace ShapeTest.Business.UnitTests
{
    [TestClass]
    public class ShapeRepositoryTests
    {
        [TestMethod]
        public void ShouldAddTringleToRepository()
        {
            var shape = new Triangle();

            var shapeRepository = new ShapeRepository();

            shapeRepository.AddShape(shape);
            var shapes = shapeRepository.GetShapes();

            CollectionAssert.Contains(shapes, shape);
        }

        [TestMethod]
        public void ShouldAddCircleToRepository()
        {
            var shape = new Circle();

            var shapeRepository = new ShapeRepository();
            
            shapeRepository.AddShape(shape);
            var shapes = shapeRepository.GetShapes();

            CollectionAssert.Contains(shapes, shape);
        }
    }
}