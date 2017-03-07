using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Cogent_Deals
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            TabbedPage TabsPage = new TabbedPage() { Title = "Deals" };
            TabsPage.Children.Add(new MainPage(109) { Title = "Main" });
            TabsPage.Children.Add(new MainPage(105) { Title = "Computers" });
            TabsPage.Children.Add(new MainPage(106) { Title = "Graphics Cards" });
            TabsPage.Children.Add(new MainPage(108) { Title = "Mobile" });

            MainPage = new NavigationPage(TabsPage);
            MainPage.SetValue(NavigationPage.BarTextColorProperty, Color.White);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
