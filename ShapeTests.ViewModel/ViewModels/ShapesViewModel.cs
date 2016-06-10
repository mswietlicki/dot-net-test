using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IUserInteraction _UserInteraction;

        public ShapesViewModel(IShapeRepository shapeRepo, 
                               IComputeAreaService computeAreaService,
                               ISubmissionService submissionService,
                               IUserInteraction userInteraction)
        {
            _ShapeRepo = shapeRepo;
            _ComputeAreaService = computeAreaService;
            _SubmissionService = submissionService;
            _UserInteraction = userInteraction;

            ShapeListItems = new ObservableCollection<ShapeListItemViewModel>();

            AddShapeCommand = new MvxCommand(AddShape);
            RemoveShapeCommand = new MvxCommand(RemoveSelectedTriangle);
            ComputeAreaCommand = new MvxCommand(ComputeTotalArea);
            SubmitAreaCommand = new MvxCommand(SubmitArea);
        }
        public bool IsSubmitEnabled { get; set; } = true;

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

        public async void SubmitArea()
        {
            IsSubmitEnabled = false;
            try
            {
                await Task.Run(() => _SubmissionService.SubmitTotalArea(TotalArea));
                _UserInteraction.Alert("Submit successful.", "Submit successful");
            }
            catch (Exception ex)
            {
                _UserInteraction.Alert(ex.Message, "Submit error");
            }
            finally
            {
                IsSubmitEnabled = true;
            }
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
