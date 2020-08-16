using Prism.Navigation;

namespace TabbedPageTest.ViewModels
{
    public class GroupsPageViewModel : ViewModelBase
    {
        private bool _isActive;

        public GroupsPageViewModel(INavigationService navigationService)
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
