using System.Runtime.InteropServices.ComTypes;
using PropertyChanged;
using ShapeTest.Business.Entities;

namespace ShapeTests.ViewModel.ViewModels.Shapes
{
    [ImplementPropertyChanged]
    public class TriangleViewModel : ShapeViewModel
    {
        public Triangle Triangle
        {
            get { return Shape as Triangle; }
            set { Shape = value; }
        }

        public string Name
        {
            get { return Triangle.Name; }
            set { Triangle.Name = value; }
        }

        public double Base
        {
            get { return Triangle.Base; }
            set { Triangle.Base = value; }
        }

        public double Height
        {
            get { return Triangle.Height; }
            set { Triangle.Height = value; }
        }
    }
}
