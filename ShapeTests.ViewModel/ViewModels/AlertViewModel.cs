using MvvmCross.Core.ViewModels;
using PropertyChanged;

namespace ShapeTests.ViewModel.ViewModels
{
    [ImplementPropertyChanged]
    public class AlertViewModel : ViewModel, IPopupViewModel
    {
        public string Message { get; set; }
        public bool IsModal => true;
        public bool TopMost => true;
        public int OwnerId { get; set; }
        public MvxCommand CloseCommand { get; set; }

        public AlertViewModel()
        {
            CloseCommand = new MvxCommand(Cancel);
        }
        public void Init(string message)
        {
            Message = message;
        }

        public void Cancel()
        {
            Close(this);
        }
    }
}