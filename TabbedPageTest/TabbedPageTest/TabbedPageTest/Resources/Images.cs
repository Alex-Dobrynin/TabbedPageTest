using System.Reflection;

using Xamarin.Forms;

namespace TabbedPageTest.Resources
{
    public static class Images
    {
        const string CommonUrl = "TabbedPageTest.Resources";

        public static ImageSource Groups { get; } = GetIconUrl("groups.png");
        public static ImageSource Home { get; } = GetIconUrl("home.png");
        public static ImageSource HomeSelected { get; } = GetIconUrl("homeSelected.png");
        public static ImageSource Notifications { get; } = GetIconUrl("notifications.png");
        public static ImageSource Profile { get; } = GetIconUrl("profile.png");
        public static ImageSource Search { get; } = GetIconUrl("search.png");

        private static ImageSource GetIconUrl(string name)
        {
            return ImageSource.FromResource($"{CommonUrl}.{name}", typeof(Images).GetTypeInfo().Assembly);
        }
    }
}
