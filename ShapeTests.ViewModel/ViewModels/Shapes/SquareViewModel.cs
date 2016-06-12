using PropertyChanged;
using ShapeTest.Business.Entities;

namespace ShapeTests.ViewModel.ViewModels.Shapes
{
    [ImplementPropertyChanged]
    public class SquareViewModel : ShapeViewModel
    {
        public Square Square
        {
            get { return Shape as Square; }
            set { Shape = value; }
        }

        public string Name
        {
            get { return Square.Name; }
            set { Square.Name = value; }
        }

        public double Lenght
        {
            get { return Square.Lenght; }
            set { Square.Lenght = value; }
        }
    }
}