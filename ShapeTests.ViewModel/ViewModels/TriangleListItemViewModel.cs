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

        //public override void RaisePropertyChanged(PropertyChangedEventArgs changedArgs)
        //{
        //    base.RaisePropertyChanged(changedArgs);

        //    var changedEventHandler = PropertyChanged;
        //    if (changedEventHandler == null)
        //        return;
        //    changedEventHandler(this, changedArgs);
        //}
    }
}
