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
            switch (Device.OS)
            {
                case TargetPlatform.Android:
                    MainPage = new AndroidRootPage();
                    break;
                case TargetPlatform.iOS:
                    MainPage = new NavigationPage(new iOSRootPage());
                    break;
                //case TargetPlatform.Windows:
                //case TargetPlatform.WinPhone:
                default:
                    throw new NotImplementedException();
            }
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
