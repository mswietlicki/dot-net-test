using PropertyChanged;
using ShapeTest.Business.Entities;

namespace ShapeTests.ViewModel.ViewModels
{
    [ImplementPropertyChanged]
    public class TriangleViewModel : ViewModel
    {
        public Triangle Triangle { get; set; }
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
