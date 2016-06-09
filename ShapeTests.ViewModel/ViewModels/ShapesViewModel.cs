using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using MvvmCross.Core.ViewModels;
using PropertyChanged;
using ShapeTest.Business.Entities;
using ShapeTest.Business.Repositories;
using ShapeTest.Business.Services;
using ShapeTests.ViewModel.ViewModels.Shapes;

namespace ShapeTests.ViewModel.ViewModels
{
    [ImplementPropertyChanged]
    public class ShapesViewModel : ViewModel
    {
        private readonly IShapeRepository _ShapeRepo;
        private readonly IComputeAreaService _ComputeAreaService;
        private readonly ISubmissionService _SubmissionService;

        public ShapesViewModel(IShapeRepository shapeRepo, 
                               IComputeAreaService computeAreaService,
                               ISubmissionService submissionService)
        {
            _ShapeRepo = shapeRepo;
            _ComputeAreaService = computeAreaService;
            _SubmissionService = submissionService;

            ShapeListItems = new ObservableCollection<ShapeListItemViewModel>();

            AddShapeCommand = new MvxCommand(AddShape);
            RemoveShapeCommand = new MvxCommand(RemoveSelectedTriangle);
            ComputeAreaCommand = new MvxCommand(ComputeTotalArea);
            SubmitAreaCommand = new MvxCommand(SubmitArea);
        }

        public ObservableCollection<ShapeListItemViewModel> ShapeListItems { get; set; }

        public ShapeListItemViewModel SelectedShapeListItemViewModel { get; set; }

        public TriangleViewModel SelectedTriangleContentViewModel { get; set; }

        public double TotalArea { get; set; }

        public MvxCommand AddShapeCommand { get; set; }

        public MvxCommand RemoveShapeCommand { get; set; }

        public MvxCommand ComputeAreaCommand { get; set; }

        public MvxCommand SubmitAreaCommand { get; set; }

        public override void RaisePropertyChanged(PropertyChangedEventArgs changedArgs)
        {
            base.RaisePropertyChanged(changedArgs);

            if (changedArgs.PropertyName == nameof(SelectedShapeListItemViewModel))
            {
                UpdateTriangleContent();
            }
        }

        public override void Start()
        {
           var shapes = _ShapeRepo.GetShapes();
           ShapeListItems = CreateListViewModelsFromTriangeList(shapes.Cast<Triangle>().ToList());
           SelectedShapeListItemViewModel = ShapeListItems.FirstOrDefault();

            _ShapeRepo.TriangleAdded += OnShapeAdded;
        }

        public void AddShape()
        {
            ShowViewModel<AddShapeViewModel>();
        }

        public void OnShapeAdded(object sender, TriangleEventArgs args)
        {
            var viewModel = new ShapeListItemViewModel { Shape = args.Triangle };
            ShapeListItems.Add(viewModel);
        }

        public void RemoveSelectedTriangle()
        {
            if (SelectedShapeListItemViewModel != null)
            {
                var viewModelToDelete = SelectedShapeListItemViewModel;
                SelectedTriangleContentViewModel = null;
                _ShapeRepo.RemoveShape(viewModelToDelete.Shape);
                ShapeListItems.Remove(viewModelToDelete);
            }
        }

        public void ComputeTotalArea()
        {
            TotalArea = _ComputeAreaService.ComputeTotalArea();
        }

        public void SubmitArea()
        {
            _SubmissionService.SubmitTotalArea(TotalArea);
        }

        private ObservableCollection<ShapeListItemViewModel> CreateListViewModelsFromTriangeList(IEnumerable<Triangle> triangles)
        {
            var viewModels = triangles.Select(_ => new ShapeListItemViewModel { Shape = _ });
            return new ObservableCollection<ShapeListItemViewModel>(viewModels);
        }

        private void UpdateTriangleContent()
        {
            if (SelectedShapeListItemViewModel != null)
            {
                var contentViewModel = new TriangleViewModel
                {
                    Triangle = SelectedShapeListItemViewModel.Shape as Triangle
                };
                SelectedTriangleContentViewModel = contentViewModel;
            }
            else
            {
                SelectedShapeListItemViewModel = null;
            }
        }
    }
}
