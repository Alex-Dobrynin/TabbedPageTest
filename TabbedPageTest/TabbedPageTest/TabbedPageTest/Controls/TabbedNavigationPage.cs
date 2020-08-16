using System.Runtime.CompilerServices;

using Xamarin.Forms;

namespace TabbedPageTest.Controls
{
    public class TabbedNavigationPage : NavigationPage
    {
        public TabbedNavigationPage()
        {
            this.SetBinding(Page.IconImageSourceProperty, new Binding("RootPage.IconImageSource", BindingMode.TwoWay, source: this));
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(Parent))
            {
                ParentPage = Parent;
            }
        }

        #region ParentPage
        public Element ParentPage
        {
            get { return (Element)GetValue(ParentPageProperty); }
            set { SetValue(ParentPageProperty, value); }
        }

        public static readonly BindableProperty ParentPageProperty =
            BindableProperty.Create(
                nameof(ParentPage),
                typeof(Element),
                typeof(TabbedNavigationPage)
                );
        #endregion
    }
}
