using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeTest.Business.Entities;
using ShapeTests.ViewModel.ViewModels;

namespace ShapeTest.ViewModel.UnitTests
{
    [TestClass]
    public class ShapeListViewModelTests
    {
        [TestMethod]
        public void ShouldUpdateViewModelNameWhenTriangleChanged()
        {
            // Arrange
            const string expectedName = "NewName";

            var testTriangle = new Triangle { Name = expectedName };
            // Act
            var viewModel = new ShapeListItemViewModel 
            {
                Shape = testTriangle
            };
            // Assert
            viewModel.ShapeName.Should().Be(expectedName);
        }

        [TestMethod]
        public void ShouldUpdateViewModelNameWhenTriangleNameChanged()
        {
            // Arrange
            const string oldName = "oldName";
            const string expectedName = "NewName";

            var testTriangle = new Triangle { Name = oldName };
            var viewModel = new ShapeListItemViewModel 
            {
                Shape = testTriangle
            };
            // Act
            testTriangle.Name = expectedName;
            // Assert
            viewModel.ShapeName.Should().Be(expectedName);
        }
        
        [TestMethod]
        public void ShouldRiseViewModelTriangleNameChangeEventWhenTriangleNameChanged()
        {
            // Arrange
            var testTriangle = new Triangle { Name = "NewName" };
            var eventWasDispatched = false;
            var viewModel = new ShapeListItemViewModel();
            viewModel.ShouldAlwaysRaiseInpcOnUserInterfaceThread(false);
            viewModel.PropertyChanged += (sender, args) => { eventWasDispatched = true; };
            // Act
            viewModel.Shape = testTriangle;
            // Assert
            Assert.IsTrue(eventWasDispatched);
        }

        [TestMethod]
        public void ShouldAddCircleToShapeListItemViewModel()
        {
            // Arrange
            const string expectedName = "NewName";

            var shape = new Circle { Name = expectedName };
            // Act
            var viewModel = new ShapeListItemViewModel 
            {
                Shape = shape
            };
            // Assert
            viewModel.ShapeName.Should().Be(expectedName);
        }

        [TestMethod]
        public void ShouldAddRectangleToShapeListItemViewModel()
        {
            // Arrange
            const string expectedName = "NewName";

            var shape = new Rectangle() { Name = expectedName };
            // Act
            var viewModel = new ShapeListItemViewModel 
            {
                Shape = shape
            };
            // Assert
            viewModel.ShapeName.Should().Be(expectedName);
        }
    }
}
