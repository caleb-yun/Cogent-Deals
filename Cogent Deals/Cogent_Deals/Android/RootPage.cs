using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Cogent_Deals
{
    public class AndroidRootPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> pages;
        public AndroidRootPage()
        {
            pages = new Dictionary<int, NavigationPage>();
            Master = new MenuPage(this);

            pages.Add(0, new NavigationPage(new HomePage()));

            Detail = pages[0];
        }

        public async Task NavigateAsync(int menuId)
        {
            NavigationPage newPage = null;
            if (!pages.ContainsKey(menuId))
            {
                //only cache specific pages
                switch (menuId)
                {
                    case (int)AppPage.Home:
                        pages.Add(menuId, new NavigationPage(new HomePage()));
                        break;
                    case (int)AppPage.Computers:
                        pages.Add(menuId, new NavigationPage(new DealsPage(105)));
                        break;
                    case (int)AppPage.GraphicsCards:
                        pages.Add(menuId, new NavigationPage(new DealsPage(106)));
                        break;
                    case (int)AppPage.Mobile:
                        newPage = new NavigationPage(new DealsPage(108));
                        break;
                }
            }

            if (newPage == null)
                newPage = pages[menuId];

            if (newPage == null)
                return;

            //if we are on the same tab and pressed it again.
            if (Detail == newPage)
            {
                await newPage.Navigation.PopToRootAsync();
            }

            Detail = newPage;
        }

        public enum AppPage
        {
            Home,
            Computers,
            GraphicsCards,
            Mobile
        }
    }
}
