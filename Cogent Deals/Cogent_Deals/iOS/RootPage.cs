using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Cogent_Deals
{
    public class iOSRootPage : TabbedPage
    {
        public iOSRootPage()
        {
            Title = "Deals";

            Children.Add(new HomePage() { Title = "Home", Icon="tab_home.png" });
            Children.Add(new DealsPage(105) { Title = "Computers", Icon = "tab_about.png" });
            Children.Add(new DealsPage(106) { Title = "Graphics Cards", Icon = "tab_about.png" });
            Children.Add(new DealsPage(108) { Title = "Mobile", Icon = "tab_about.png" });
        }
    }
}
