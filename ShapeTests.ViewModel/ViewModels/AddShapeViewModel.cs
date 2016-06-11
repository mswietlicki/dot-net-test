using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IShapeFactory _ShapeFactory;

        public bool IsModal => true;
        public bool TopMost => true;
        public int OwnerId { get; set; }
        public List<string> ShapeTypesList { get; set; }
        public string SelectedShapeType { get; set; }
        public MvxCommand AddShapeCommand { get; set; }
        public MvxCommand CancelCommand { get; set; }
        
        public AddShapeViewModel(IShapeRepository shapeRepo, IShapeFactory shapeFactory)
        {
            _ShapeRepo = shapeRepo;
            _ShapeFactory = shapeFactory;
            ShapeTypesList = shapeFactory.GetShapeTypes().ToList();
            SelectedShapeType = ShapeTypesList.First();

            AddShapeCommand = new MvxCommand(AddShape);
            CancelCommand = new MvxCommand(Cancel);
        }

        public void AddShape()
        {
            var shape = _ShapeFactory.Create(SelectedShapeType);
            _ShapeRepo.AddShape(shape);
            Close(this);
        }

        public void Cancel()
        {
            Close(this);
        }
    }
}
