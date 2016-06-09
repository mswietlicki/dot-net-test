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

            TriangleListItems = new ObservableCollection<TriangleListItemViewModel>();

            AddTriangleCommand = new MvxCommand(AddTriangle);
            RemoveTriangleCommand = new MvxCommand(RemoveSelectedTriangle);
            ComputeAreaCommand = new MvxCommand(ComputeTotalArea);
            SubmitAreaCommand = new MvxCommand(SubmitArea);
        }

        public ObservableCollection<TriangleListItemViewModel> TriangleListItems { get; set; }

        public TriangleListItemViewModel SelectedTriangleListItemViewModel { get; set; }

        public TriangleViewModel SelectedTriangleContentViewModel { get; set; }

        public double TotalArea { get; set; }

        public MvxCommand AddTriangleCommand { get; set; }

        public MvxCommand RemoveTriangleCommand { get; set; }

        public MvxCommand ComputeAreaCommand { get; set; }

        public MvxCommand SubmitAreaCommand { get; set; }

        public override void RaisePropertyChanged(PropertyChangedEventArgs changedArgs)
        {
            base.RaisePropertyChanged(changedArgs);

            if (changedArgs.PropertyName == nameof(SelectedTriangleListItemViewModel))
            {
                UpdateTriangleContent();
            }
        }

        public override void Start()
        {
           var shapes = _ShapeRepo.GetShapes();
           TriangleListItems = CreateListViewModelsFromTriangeList(shapes.Cast<Triangle>().ToList());
           SelectedTriangleListItemViewModel = TriangleListItems.FirstOrDefault();

            _ShapeRepo.TriangleAdded += OnShapeAdded;
        }

        public void AddTriangle()
        {
            ShowViewModel<AddTriangleViewModel>();
        }

        public void OnShapeAdded(object sender, TriangleEventArgs args)
        {
            var viewModel = new TriangleListItemViewModel { Triangle = args.Triangle };
            TriangleListItems.Add(viewModel);
        }

        public void RemoveSelectedTriangle()
        {
            if (SelectedTriangleListItemViewModel != null)
            {
                var viewModelToDelete = SelectedTriangleListItemViewModel;
                SelectedTriangleContentViewModel = null;
                _ShapeRepo.RemoveTriangle(viewModelToDelete.Triangle);
                TriangleListItems.Remove(viewModelToDelete);
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

        private ObservableCollection<TriangleListItemViewModel> CreateListViewModelsFromTriangeList(IEnumerable<Triangle> triangles)
        {
            var viewModels = triangles.Select(_ => new TriangleListItemViewModel { Triangle = _ });
            return new ObservableCollection<TriangleListItemViewModel>(viewModels);
        }

        private void UpdateTriangleContent()
        {
            if (SelectedTriangleListItemViewModel != null)
            {
                var contentViewModel = new TriangleViewModel
                {
                    Triangle = SelectedTriangleListItemViewModel.Triangle
                };
                SelectedTriangleContentViewModel = contentViewModel;
            }
            else
            {
                SelectedTriangleListItemViewModel = null;
            }
        }
    }
}
