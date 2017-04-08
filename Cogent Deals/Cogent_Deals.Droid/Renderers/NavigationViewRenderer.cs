using System;
using Xamarin.Forms.Platform.Android;
using Android.Support.Design.Widget;
using Android.Runtime;
using Xamarin.Forms;
using Cogent_Deals.Droid;
using Android.Widget;
using Android.Views;


[assembly: ExportRenderer(typeof(Cogent_Deals.NavigationView), typeof(NavigationViewRenderer))]
namespace Cogent_Deals.Droid
{
    public class NavigationViewRenderer : ViewRenderer<Cogent_Deals.NavigationView, Android.Support.Design.Widget.NavigationView>
    {
        Android.Support.Design.Widget.NavigationView navView;
        //ImageView profileImage;
        //TextView profileName;
        protected override void OnElementChanged(ElementChangedEventArgs<Cogent_Deals.NavigationView> e)
        {

            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
                return;

            var view = Inflate(Forms.Context, Resource.Layout.nav_view, null);
            navView = view.JavaCast<Android.Support.Design.Widget.NavigationView>();

            SetNativeControl(navView);

            navView.NavigationItemSelected += NavView_NavigationItemSelected;

            navView.SetCheckedItem(Resource.Id.nav_home);
        }

        IMenuItem previousItem;

        void NavView_NavigationItemSelected(object sender, Android.Support.Design.Widget.NavigationView.NavigationItemSelectedEventArgs e)
        {
            //if (previousItem != null)
                //previousItem.SetChecked(false);

            navView.SetCheckedItem(e.MenuItem.ItemId);

            previousItem = e.MenuItem;

            int id = 0;
            switch (e.MenuItem.ItemId)
            {
                case Resource.Id.nav_home:
                    id = (int)AppPage.Home;
                    break;
                case Resource.Id.nav_deals:
                    id = (int)AppPage.Deals;
                    break;
                case Resource.Id.nav_settings:
                    id = (int)AppPage.Settings;
                    break;
                case Resource.Id.nav_about:
                    id = (int)AppPage.About;
                    break;
            }
            this.Element.OnNavigationItemSelected(new Cogent_Deals.NavigationItemSelectedEventArgs
            {
                Index = id
            });
        }

        public enum AppPage
        {
            Home,
            Deals,
            Settings,
            About
        }
    }
}