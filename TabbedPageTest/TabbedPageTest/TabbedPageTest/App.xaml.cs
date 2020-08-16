using Prism;
using Prism.Ioc;
using Prism.Navigation;

using TabbedPageTest.Controls;
using TabbedPageTest.Navigation;
using TabbedPageTest.Views;

using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;

namespace TabbedPageTest
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            var result = await NavigationService.NavigateAsync($"{ViewNames.MDPage}/{ViewNames.MainTabbedPage}" +
                    $"?{KnownNavigationParameters.CreateTab}={ViewNames.TabbedNavigationPage}|{ViewNames.HomePage}" +
                    $"&{KnownNavigationParameters.CreateTab}={ViewNames.TabbedNavigationPage}|{ViewNames.SearchPage}" +
                    $"&{KnownNavigationParameters.CreateTab}={ViewNames.TabbedNavigationPage}|{ViewNames.GroupsPage}" +
                    $"&{KnownNavigationParameters.CreateTab}={ViewNames.TabbedNavigationPage}|{ViewNames.NotificationsPage}" +
                    $"&{KnownNavigationParameters.CreateTab}={ViewNames.TabbedNavigationPage}|{ViewNames.ProfilePage}" +
                    $"&{KnownNavigationParameters.SelectedTab}={ViewNames.HomePage}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<TabbedNavigationPage>(ViewNames.TabbedNavigationPage);
            containerRegistry.RegisterForNavigation<MainTabbedPage>(ViewNames.MainTabbedPage);
            containerRegistry.RegisterForNavigation<MDPage>(ViewNames.MDPage);
            containerRegistry.RegisterForNavigation<HomePage>(ViewNames.HomePage);
            containerRegistry.RegisterForNavigation<SearchPage>(ViewNames.SearchPage);
            containerRegistry.RegisterForNavigation<GroupsPage>(ViewNames.GroupsPage);
            containerRegistry.RegisterForNavigation<NotificationsPage>(ViewNames.NotificationsPage);
            containerRegistry.RegisterForNavigation<ProfilePage>(ViewNames.ProfilePage);
        }
    }
}
