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

        public void OnTriangleChanged()
        {
            Shape.PropertyChanged += Triangle_PropertyChanged;
        }

        private void Triangle_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
           RaisePropertyChanged(() => ShapeName);
        }
    }
}
