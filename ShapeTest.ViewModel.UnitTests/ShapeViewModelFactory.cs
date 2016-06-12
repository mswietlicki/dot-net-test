using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeTest.Business.Entities;
using ShapeTests.ViewModel.ViewModels.Shapes;

namespace ShapeTest.ViewModel.UnitTests
{
    [TestClass]
    public class ShapeViewModelFactoryTests
    {
        [TestMethod]
        public void ShouldReturnTriangleViewModel()
        {
            var triangle = new Triangle();
            var viewModelFactory = new ShapeViewModelFactory();

            var shapeViewModel = viewModelFactory.Create(triangle);

            Assert.IsInstanceOfType(shapeViewModel, typeof(TriangleViewModel));
        }

        [TestMethod]
        public void ShouldReturnCircleViewModel()
        {
            var circle = new Circle();
            var viewModelFactory = new ShapeViewModelFactory();

            var shapeViewModel = viewModelFactory.Create(circle);

            Assert.IsInstanceOfType(shapeViewModel, typeof(CircleViewModel));
        }


        [TestMethod]
        public void ShouldReturnRectangleViewModel()
        {
            var rectangle = new Rectangle();
            var viewModelFactory = new ShapeViewModelFactory();

            var shapeViewModel = viewModelFactory.Create(rectangle);

            Assert.IsInstanceOfType(shapeViewModel, typeof(RectangleViewModel));
        }


        [TestMethod]
        public void ShouldReturnSquareViewModel()
        {
            var square = new Square();
            var viewModelFactory = new ShapeViewModelFactory();

            var shapeViewModel = viewModelFactory.Create(square);

            Assert.IsInstanceOfType(shapeViewModel, typeof(SquareViewModel));
        }
    }
}