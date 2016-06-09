using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeTest.Business.Entities;
using ShapeTests.ViewModel.ViewModels;
using ShapeTests.ViewModel.ViewModels.Shapes;

namespace ShapeTest.ViewModel.UnitTests
{
    [TestClass]
    public class CircleViewModelTests
    {
        [TestMethod]
        public void ShouldUpdateViewModelOnCircleChanged()
        {
            // Arrange
            const string expectedName = "NewName";
            const double expectedRadius = 4;

            var circle = new Circle { Name = expectedName, Radius = expectedRadius };
            // Act
            var viewModel = new CircleViewModel { Circle = circle };
            
            // Assert
            viewModel.Name.Should().Be(expectedName);
            viewModel.Radius.Should().Be(expectedRadius);
        }

        [TestMethod]
        public void ShouldUpdateCircleRadiusWhenViewModelRadiusChanges()
        {
            // Arrange
            const string expectedName = "NewName";
            const double oldRadius = 4;
            const double expectedRadius = 6;

            var circle = new Circle { Name = expectedName, Radius = oldRadius };
            var viewModel = new CircleViewModel { Circle = circle };

            // Act
            viewModel.Radius = expectedRadius;

            // Assert
            viewModel.Name.Should().Be(expectedName);
            viewModel.Radius.Should().Be(expectedRadius);

            circle.Name.Should().Be(expectedName);
            circle.Radius.Should().Be(expectedRadius);
        }

        [TestMethod]
        public void ShouldUpdateViewModelRadiusWhenCircleRadiusChanges()
        {
            // Arrange
            const string expectedName = "NewName";
            const double oldRadius = 4;
            const double expectedRadius = 6;

            var circle = new Circle { Name = expectedName, Radius = oldRadius };
            var viewModel = new CircleViewModel { Circle = circle };

            // Act
            circle.Radius = expectedRadius;

            // Assert
            viewModel.Name.Should().Be(expectedName);
            viewModel.Radius.Should().Be(expectedRadius);

            circle.Name.Should().Be(expectedName);
            circle.Radius.Should().Be(expectedRadius);
        }
    }
}