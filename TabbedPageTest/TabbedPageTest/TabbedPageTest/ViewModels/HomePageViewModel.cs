using Prism.Navigation;

namespace TabbedPageTest.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private bool _isActive;

        public HomePageViewModel(INavigationService navigationService)
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
