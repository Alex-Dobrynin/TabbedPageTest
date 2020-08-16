using System.Runtime.CompilerServices;

using Prism.Behaviors;

using Xamarin.Forms;

namespace TabbedPageTest.Behaviors
{
    public class ActivePageBehavior : BehaviorBase<Page>
    {
        protected override void OnAttachedTo(Page bindable)
        {
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Page bindable)
        {
            base.OnDetachingFrom(bindable);
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == PageProperty.PropertyName || propertyName == CurrentPageProperty.PropertyName)
            {
                IsActive = Page == CurrentPage;
            }
            else if (propertyName == IsActiveProperty.PropertyName && IsActive)
            {
                CurrentPage = Page;
            }
        }

        #region IsActive
        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }

        public static readonly BindableProperty IsActiveProperty =
            BindableProperty.Create(
                nameof(IsActive),
                typeof(bool),
                typeof(ActivePageBehavior)
                );
        #endregion

        #region Page
        public object Page
        {
            get { return (object)GetValue(PageProperty); }
            set { SetValue(PageProperty, value); }
        }

        public static readonly BindableProperty PageProperty =
            BindableProperty.Create(
                nameof(Page),
                typeof(object),
                typeof(ActivePageBehavior)
                );
        #endregion

        #region CurrentPage
        public object CurrentPage
        {
            get { return (object)GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }

        public static readonly BindableProperty CurrentPageProperty =
            BindableProperty.Create(
                nameof(CurrentPage),
                typeof(object),
                typeof(ActivePageBehavior)
                );
        #endregion
    }
}
