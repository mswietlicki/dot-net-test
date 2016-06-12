using PropertyChanged;
using ShapeTest.Business.Entities;

namespace ShapeTests.ViewModel.ViewModels.Shapes
{
    [ImplementPropertyChanged]
    public class RectangleViewModel : ShapeViewModel
    {
        public Rectangle Rectangle
        {
            get { return Shape as Rectangle; }
            set { Shape = value; }
        }
        public string Name
        {
            get { return Rectangle.Name; }
            set { Rectangle.Name = value; }
        }

        public double Height
        {
            get { return Rectangle.Height; }
            set { Rectangle.Height = value; }
        }
        public double Width
        {
            get { return Rectangle.Width; }
            set { Rectangle.Width = value; }
        }
    }
}