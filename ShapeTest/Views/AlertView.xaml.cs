using ShapeTests.ViewModel.ViewModels;

namespace ShapeTest.Wpf.Views
{
    public partial class AlertView
    {
        public AlertView()
        {
            InitializeComponent();
        }

        public new AlertViewModel ViewModel
        {
            get { return (AlertViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
    }
}
