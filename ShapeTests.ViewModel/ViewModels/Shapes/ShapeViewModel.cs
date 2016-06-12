using System.Dynamic;
using PropertyChanged;
using ShapeTest.Business.Entities;

namespace ShapeTests.ViewModel.ViewModels.Shapes
{
    [ImplementPropertyChanged]
    public abstract class ShapeViewModel : ViewModel
    {
        public Shape Shape { get; set; } 
    }
}