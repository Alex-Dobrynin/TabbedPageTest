
using Prism.Navigation;

namespace TabbedPageTest.ViewModels
{
    public class NotificationsPageViewModel : ViewModelBase
    {
        private bool _isActive;

        public NotificationsPageViewModel(INavigationService navigationService)
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
