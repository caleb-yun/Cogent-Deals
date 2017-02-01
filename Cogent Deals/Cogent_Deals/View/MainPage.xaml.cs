using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Cogent_Deals
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
            this.viewModel = new MainPageViewModel();
        }

        async public void OnItemTapped(object o, ItemTappedEventArgs e)
        {
            var per = e.Item as Deal;
            //DisplayAlert("Selection made", "You tapped on " + per.Name, "OK");
            ((ListView)o).SelectedItem = null; // Disable selection
            await Navigation.PushAsync(new DealPage(per), true); // Navigate to DealPage
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            this.DealList.IsRefreshing = true;
            //this.BusyIndicator.IsVisible = true;
            //this.BusyIndicator.IsRunning = true;
            try
            {
                await this.viewModel.InitializeDealsAsync();
                // Data-binding:
                this.BindingContext = this.viewModel;
            }
            catch (InvalidOperationException ex)
            {
                await DisplayAlert("Error", "Check your network connection.", "OK");
                return;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
                return;
            }
            finally
            {
                this.DealList.IsRefreshing = false;
                //this.BusyIndicator.IsVisible = false;
                //this.BusyIndicator.IsRunning = false;
            }
        }
    }
}
