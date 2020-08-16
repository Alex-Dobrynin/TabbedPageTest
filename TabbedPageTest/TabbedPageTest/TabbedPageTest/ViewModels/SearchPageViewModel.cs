
using Prism.Navigation;

namespace TabbedPageTest.ViewModels
{
    public class SearchPageViewModel : ViewModelBase
    {
        private bool _isActive;

        public SearchPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }

        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
    }
}
