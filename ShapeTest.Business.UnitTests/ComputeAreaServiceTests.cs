using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShapeTest.Business.Entities;
using ShapeTest.Business.Repositories;
using ShapeTest.Business.Services;

namespace ShapeTest.Business.UnitTests
{
    [TestClass]
    public class ComputeAreaServiceTests
    {
        private const double ExpectedPrecision = 0.001;

        private MockRepository _MockRepository;
        private Mock<IShapeRepository> _MockTrianglesRepository;
      
        [TestInitialize]
        public void Setup()
        {
            _MockRepository = new MockRepository(MockBehavior.Strict);
            _MockTrianglesRepository = _MockRepository.Create<IShapeRepository>();
        }

        [TestMethod]
        public void ShouldComputeTotalAreaForTriangles()
        {
            // Arrange
            const double expectedResult = 13;

            var triangles = new List<Shape>
            {
                new Triangle
                    {
                        Base = 2,
                        Height = 4
                    },
                new Triangle
                    {
                        Base = 3,
                        Height = 6
                    }                                   
            };

            _MockTrianglesRepository.Setup(m => m.GetShapes()).Returns(triangles);
            var computeAreaService = new ComputeAreaService(_MockTrianglesRepository.Object);

            // Act
            var result = computeAreaService.ComputeTotalArea();

            // Assert
            result.Should().BeApproximately(expectedResult, ExpectedPrecision);

            _MockTrianglesRepository.VerifyAll();
        }

        [TestMethod]
        public void ShouldComputeTotalAreaForCircles()
        {
            const double expectedResult = 5 * Math.PI;
            var shapes = new List<Shape> 
            {
                new Circle { Radius = 2 },
                new Circle { Radius = 1 }
            };

            _MockTrianglesRepository.Setup(m => m.GetShapes()).Returns(shapes);
            var computeAreaService = new ComputeAreaService(_MockTrianglesRepository.Object);

            var result = computeAreaService.ComputeTotalArea();

            result.Should().BeApproximately(expectedResult, ExpectedPrecision);

            _MockTrianglesRepository.VerifyAll();
        }
    }
}
