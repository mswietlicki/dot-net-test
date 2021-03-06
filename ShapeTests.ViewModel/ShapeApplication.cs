﻿using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using ShapeTests.ViewModel.ViewModels;
using ShapeTests.ViewModel.ViewModels.Shapes;

namespace ShapeTests.ViewModel
{
    using ShapeTest.Business.Repositories;
    using ShapeTest.Business.Services;

    public class ShapeApplication : MvxApplication
    {
        public ShapeApplication()
        {
            Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<ShapesViewModel>());
        }

        public override void Initialize()
        {
            Mvx.LazyConstructAndRegisterSingleton<IShapeRepository>(() => new ShapeRepository());
            Mvx.RegisterType<IComputeAreaService, ComputeAreaService>();
            Mvx.RegisterType<IShapeFactory, ShapeFactory>();
            Mvx.RegisterType<IShapeViewModelFactory, ShapeViewModelFactory>();
            Mvx.RegisterType<ISubmissionService, SubmissionService>();
            Mvx.RegisterType<IUserInteraction, UserInteraction>();
        }
    }
}
