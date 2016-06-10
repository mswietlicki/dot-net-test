using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;

namespace ShapeTests.ViewModel.ViewModels
{
    public class UserInteraction : IUserInteraction
    {
        private readonly IMvxViewDispatcher _ViewDispatcher;
        public UserInteraction(IMvxViewDispatcher viewDispatcher)
        {
            _ViewDispatcher = viewDispatcher;
        }
        public void Alert(string message, string title)
        {
            var paramiters = new Dictionary<string, string> 
            {
                { nameof(message), message }
            };
            _ViewDispatcher.ShowViewModel(new MvxViewModelRequest(typeof(AlertViewModel), new MvxBundle(paramiters), null, null));
        }
    }
}