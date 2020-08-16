
using Prism.Navigation;

namespace TabbedPageTest.ViewModels
{
    public class ProfilePageViewModel : ViewModelBase
    {
        private bool _isActive;

        public ProfilePageViewModel(INavigationService navigationService)
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
