using MvvmCross.Core.ViewModels;
using PropertyChanged;
using ShapeTest.Business.Entities;
using ShapeTest.Business.Repositories;

namespace ShapeTests.ViewModel.ViewModels
{
    [ImplementPropertyChanged]
    public class AddShapeViewModel : ViewModel, IPopupViewModel
    {
        private readonly IShapeRepository _ShapeRepo;
        
        public bool IsModal => true;
        public bool TopMost => true;
        public int OwnerId { get; set; }
        public MvxCommand AddTriangleCommand { get; set; }
        public MvxCommand CancelCommand { get; set; }
        
        public AddShapeViewModel(IShapeRepository shapeRepo)
        {
            _ShapeRepo = shapeRepo;
            AddTriangleCommand = new MvxCommand(AddTriangle);
            CancelCommand = new MvxCommand(Cancel);
        }

        public void AddTriangle()
        {
            var triangle = new Triangle
            {
                Name = "New Triangle"
            };

            _ShapeRepo.AddShape(triangle);
            Close(this);
        }

        public void Cancel()
        {
            Close(this);
        }
    }
}
