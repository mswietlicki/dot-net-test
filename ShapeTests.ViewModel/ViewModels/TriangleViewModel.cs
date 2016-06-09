using System;
using System.ComponentModel;
using PropertyChanged;
using ShapeTest.Business.Entities;

namespace ShapeTests.ViewModel.ViewModels
{
    [ImplementPropertyChanged]
    public class TriangleViewModel : ViewModel
    {
        private Triangle _Triangle;

        public string Name { get; set; }

        public double Base { get; set; }

        public double Height { get; set; }

        public Triangle Triangle
        {
            get
            {
                return _Triangle;
            }
            set
            {
                SetAndUpdateTraingleIfChanged(value);
            }
        }

        public override void RaisePropertyChanged(PropertyChangedEventArgs changedArgs)
        {
            base.RaisePropertyChanged(changedArgs);
            if (changedArgs.PropertyName == nameof(Name))
            {
                Triangle.Name = Name;
            }
            else if (changedArgs.PropertyName == nameof(Base))
            {
                Triangle.Base = Base;
            }
            else if (changedArgs.PropertyName == nameof(Height))
            {
                Triangle.Height = Height;
            }
        }

        private void SetAndUpdateTraingleIfChanged(Triangle newTriangle)
        {
            if (!ReferenceEquals(_Triangle, newTriangle))
            {
                if (_Triangle != null)
                {
                    _Triangle.PropertyChanged -= OnTriangleChanged;
                }

                _Triangle = newTriangle;

                if (_Triangle != null)
                {
                    _Triangle.PropertyChanged += OnTriangleChanged;
                }

                UpdateViewModel();
            }
        }

        private void OnTriangleChanged(object sender, EventArgs args)
        {
            UpdateViewModel();
        }

        private void UpdateViewModel()
        {
            Name = _Triangle.Name;
            Base = _Triangle.Base;
            Height = _Triangle.Height;
        }
    }
}
