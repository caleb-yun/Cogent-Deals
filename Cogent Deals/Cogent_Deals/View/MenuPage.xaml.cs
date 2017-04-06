using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cogent_Deals
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        AndroidRootPage root;
        public MenuPage(AndroidRootPage root)
        {
            this.root = root;

            InitializeComponent();
            //BindingContext = new ContentPageViewModel();
            NavView.NavigationItemSelected += async (sender, e) =>
            {
                this.root.IsPresented = false;

                await this.root.NavigateAsync(e.Index);
            };
        }
    }
}
