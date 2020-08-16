using Android.Content;
using Android.Widget;

using Google.Android.Material.BottomNavigation;
using Google.Android.Material.Internal;

using TabbedPageTest.Droid.Renderers;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(MainTabbedPageRenderer))]
namespace TabbedPageTest.Droid.Renderers
{
    public class MainTabbedPageRenderer : TabbedPageRenderer
    {
        int lastItemId = -1;

        public MainTabbedPageRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var page = e.NewElement;

                var bottomNavigationView = (GetChildAt(0) as Android.Widget.RelativeLayout).GetChildAt(1) as BottomNavigationView;
                bottomNavigationView.NavigationItemSelected += BottomNavigationView_NavigationItemSelected;

                InitTabsItems();
            }
            if (e.OldElement != null)
            {
                var bottomNavigationView = (GetChildAt(0) as Android.Widget.RelativeLayout).GetChildAt(1) as BottomNavigationView;
                bottomNavigationView.NavigationItemSelected -= BottomNavigationView_NavigationItemSelected;
            }
        }

        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();

            var bottomNavigationView = (GetChildAt(0) as Android.Widget.RelativeLayout).GetChildAt(1) as BottomNavigationView;
            var bottomNavMenuView = bottomNavigationView.GetChildAt(0) as BottomNavigationMenuView;

            if (bottomNavigationView != null && bottomNavigationView.ItemIconTintList != null)
            {
                var colorTintList = bottomNavigationView.ItemIconTintList;
                bottomNavigationView.ItemIconTintList = null;

                for (int i = 0; i < bottomNavMenuView.ChildCount; i++)
                {
                    var item = bottomNavMenuView.GetChildAt(i) as BottomNavigationItemView;
                    if (i < 4)
                    {
                        item.SetIconTintList(colorTintList);
                    }
                }
            }
        }

        void InitTabsItems()
        {
            var bottomNavigationView = (GetChildAt(0) as Android.Widget.RelativeLayout).GetChildAt(1) as BottomNavigationView;
            bottomNavigationView.SetShiftMode(false, false);
            var bottomNavMenuView = bottomNavigationView.GetChildAt(0) as BottomNavigationMenuView;

            for (int i = 0; i < bottomNavMenuView.ChildCount; i++)
            {
                var item = bottomNavMenuView.GetChildAt(i) as BottomNavigationItemView;
                var itemTitle = item.GetChildAt(1);

                var smallTextView = (TextView)((BaselineLayout)itemTitle).GetChildAt(0);
                var largeTextView = (TextView)((BaselineLayout)itemTitle).GetChildAt(1);
                lastItemId = bottomNavMenuView.SelectedItemId;

                var color = (item.Id == bottomNavMenuView.SelectedItemId) ? Element.SelectedTabColor.ToAndroid() : Element.BarTextColor.ToAndroid();
                var iconSize = (item.Id == bottomNavMenuView.SelectedItemId) ? 26 : 24;
                smallTextView.SetTextColor(color);
                largeTextView.SetTextColor(color);
                item.SetIconSize((int)(iconSize * base.Resources.DisplayMetrics.Density));
            }
        }

        void BottomNavigationView_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            var bottomNavigationView = (GetChildAt(0) as Android.Widget.RelativeLayout).GetChildAt(1) as BottomNavigationView;
            var bottomNavMenuView = bottomNavigationView.GetChildAt(0) as BottomNavigationMenuView;

            var normalColor = Element.BarTextColor.ToAndroid();
            var selectedColor = Element.SelectedTabColor.ToAndroid();

            BottomNavigationItemView item;
            if (lastItemId != -1)
            {
                item = bottomNavMenuView.GetChildAt(lastItemId) as BottomNavigationItemView;
                SetTabItemTextColor(item, normalColor);
                item.SetIconSize((int)(24 * base.Resources.DisplayMetrics.Density));
            }

            item = bottomNavMenuView.GetChildAt(e.Item.ItemId) as BottomNavigationItemView;
            SetTabItemTextColor(item, selectedColor);
            item.SetIconSize((int)(26 * base.Resources.DisplayMetrics.Density));

            this.OnNavigationItemSelected(e.Item);
            lastItemId = e.Item.ItemId;
        }

        void SetTabItemTextColor(BottomNavigationItemView bottomNavigationItemView, Android.Graphics.Color textColor)
        {
            var itemTitle = bottomNavigationItemView.GetChildAt(1);
            var smallTextView = (TextView)((BaselineLayout)itemTitle).GetChildAt(0);
            var largeTextView = (TextView)((BaselineLayout)itemTitle).GetChildAt(1);

            smallTextView.SetTextColor(textColor);
            smallTextView.SetPadding(0, 0, 0, 0);
            largeTextView.SetTextColor(textColor);
            largeTextView.SetPadding(0, 0, 0, 0);
        }
    }
}