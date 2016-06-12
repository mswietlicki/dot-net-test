using ShapeTest.Business.Entities;

namespace ShapeTests.ViewModel.ViewModels.Shapes
{
    public interface IShapeViewModelFactory
    {
        ShapeViewModel Create(Shape shape);
    }
}