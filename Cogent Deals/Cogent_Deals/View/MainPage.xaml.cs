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
            BindingContext = this.viewModel;
        }

        async public void OnItemTapped(object o, ItemTappedEventArgs e)
        {
            var per = e.Item as Deal;
            ((ListView)o).SelectedItem = null; // Disable selection
            await Navigation.PushAsync(new DealPage(per), true); // Navigate to DealPage
        }

        private async Task LoadDataAsync()
        {
            this.DealList.IsRefreshing = true;

            try
            {
                await this.viewModel.InitializeDealsAsync();
                //this.BindingContext = this.viewModel;
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
                viewModel.Count = 0;
                this.DealList.IsRefreshing = false;
            }
        }

        private bool appearingFirstTime = true;

        protected async override void OnAppearing()
        {
            if (appearingFirstTime)
            {
                await LoadDataAsync();
            }
            else
            {
                return;
            }

            appearingFirstTime = false;
        }

        private async void ListView_Refreshing(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async void loadMore(object sender, ItemVisibilityEventArgs e)
        {
            if (viewModel.IsBusy || viewModel.Items.Count == 0)
                return;

            //hit bottom!
            if (e.Item == viewModel.Items[viewModel.Items.Count - 1])
            {
                this.BusyIndicator.IsVisible = true;
                this.BusyIndicator.IsRunning = true;

                viewModel.Count++;
                await viewModel.LoadMore(viewModel.Count);

                this.BusyIndicator.IsVisible = false;
                this.BusyIndicator.IsRunning = false;
            }
        }
    }
}
