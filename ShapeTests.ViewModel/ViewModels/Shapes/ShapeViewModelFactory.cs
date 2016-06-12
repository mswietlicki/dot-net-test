using System;
using ShapeTest.Business.Entities;

namespace ShapeTests.ViewModel.ViewModels.Shapes
{
    public class ShapeViewModelFactory : IShapeViewModelFactory
    {
        public ShapeViewModel Create(Shape shape)
        {
            if (shape == null)
                throw new ArgumentNullException(nameof(shape));

            var viewModelTypeName = $"ShapeTests.ViewModel.ViewModels.Shapes.{shape.GetType().Name}ViewModel";
            var viewModelType = Type.GetType(viewModelTypeName);
            if (viewModelType == null)
                throw new ArgumentOutOfRangeException($"No ViewModel for {shape.GetType()} found.");

            var shapeViewModel = Activator.CreateInstance(viewModelType) as ShapeViewModel;
            shapeViewModel.Shape = shape;

            return shapeViewModel;
        }
    }
}