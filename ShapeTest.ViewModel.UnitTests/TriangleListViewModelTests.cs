using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeTest.Business.Entities;
using ShapeTests.ViewModel.ViewModels;

namespace ShapeTest.ViewModel.UnitTests
{
    [TestClass]
    public class TriangleListViewModelTests
    {
        [TestMethod]
        public void ShouldUpdateViewModelNameWhenTriangleChanged()
        {
            // Arrange
            const string expectedName = "NewName";

            var testTriangle = new Triangle { Name = expectedName };
            // Act
            var viewModel = new TriangleListItemViewModel 
            {
                Triangle = testTriangle
            };
            // Assert
            viewModel.TriangleName.Should().Be(expectedName);
        }

        [TestMethod]
        public void ShouldUpdateViewModelNameWhenTriangleNameChanged()
        {
            // Arrange
            const string oldName = "oldName";
            const string expectedName = "NewName";

            var testTriangle = new Triangle { Name = oldName };
            var viewModel = new TriangleListItemViewModel 
            {
                Triangle = testTriangle
            };
            // Act
            testTriangle.Name = expectedName;
            // Assert
            viewModel.TriangleName.Should().Be(expectedName);
        }
        
        [TestMethod]
        public void ShouldRiseViewModelTriangleNameChangeEventWhenTriangleNameChanged()
        {
            // Arrange
            var testTriangle = new Triangle { Name = "NewName" };
            var eventWasDispatched = false;
            var viewModel = new TriangleListItemViewModel();
            viewModel.ShouldAlwaysRaiseInpcOnUserInterfaceThread(false);
            viewModel.PropertyChanged += (sender, args) => { eventWasDispatched = true; };
            // Act
            viewModel.Triangle = testTriangle;
            // Assert
            Assert.IsTrue(eventWasDispatched);
        }
    }
}
