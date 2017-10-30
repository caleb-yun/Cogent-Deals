using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Plugin.LocalNotifications;

namespace Cogent_Deals
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    MainPage = new AndroidRootPage();
                    break;
                case Device.iOS:
                    MainPage = new NavigationPage(new iOSRootPage());
                    break;
                //case TargetPlatform.Windows:
                //case TargetPlatform.WinPhone:
                default:
                    throw new NotImplementedException();
            }
            MainPage.SetValue(NavigationPage.BarTextColorProperty, Color.White);

            //CrossLocalNotifications.Current.Show("Hello!", "This is a notification!", 101, DateTime.Now.AddSeconds(5));
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
