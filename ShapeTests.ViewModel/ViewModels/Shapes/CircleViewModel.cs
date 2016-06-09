using PropertyChanged;
using ShapeTest.Business.Entities;

namespace ShapeTests.ViewModel.ViewModels.Shapes
{
    [ImplementPropertyChanged]
    public class CircleViewModel : ViewModel
    {
        public Circle Circle { get; set; }
        public string Name
        {
            get { return Circle.Name; }
            set { Circle.Name = value; }
        }

        public double Radius
        {
            get { return Circle.Radius; }
            set { Circle.Radius = value; }
        }
    }
}