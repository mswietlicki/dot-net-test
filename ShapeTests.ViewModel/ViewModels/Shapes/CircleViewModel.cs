using PropertyChanged;
using ShapeTest.Business.Entities;

namespace ShapeTests.ViewModel.ViewModels.Shapes
{
    [ImplementPropertyChanged]
    public class CircleViewModel : ShapeViewModel
    {
        public Circle Circle
        {
            get { return Shape as Circle; }
            set { Shape = value; }
        }

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