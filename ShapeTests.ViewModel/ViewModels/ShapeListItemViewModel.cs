using System.ComponentModel;
using PropertyChanged;
using ShapeTest.Business.Entities;

namespace ShapeTests.ViewModel.ViewModels
{
    [ImplementPropertyChanged]
    public class ShapeListItemViewModel : ViewModel
    {
        public string ShapeName => Shape.Name;
        public Shape Shape { get; set; }

        public void OnShapeChanged()
        {
            Shape.PropertyChanged += Shape_PropertyChanged;
        }

        private void Shape_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
           RaisePropertyChanged(() => ShapeName);
        }
    }
}
