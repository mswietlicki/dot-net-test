using System.ComponentModel;
using PropertyChanged;
using ShapeTest.Business.Entities;

namespace ShapeTests.ViewModel.ViewModels
{
    [ImplementPropertyChanged]
    public class TriangleListItemViewModel : ViewModel
    {
        public string TriangleName => Triangle.Name;
        public Triangle Triangle { get; set; }

        public void OnTriangleChanged()
        {
            Triangle.PropertyChanged += Triangle_PropertyChanged;
        }

        private void Triangle_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(() => TriangleName);
        }
    }
}
