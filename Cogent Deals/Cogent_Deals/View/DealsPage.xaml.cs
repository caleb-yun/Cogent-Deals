using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Cogent_Deals
{
    public partial class DealsPage : ContentPage
    {
        MainPageViewModel viewModel;

        public DealsPage(int catId)
        {
            this.viewModel = new MainPageViewModel() { CatId = catId };

            InitializeComponent();
            BindingContext = viewModel;

            //loadCatAsync(); Not Working!
            loadDataAsync();
        }

        async public void OnItemTapped(object o, ItemTappedEventArgs e)
        {
            var per = e.Item as Deal;
            ((ListView)o).SelectedItem = null; // Disable selection
            await Navigation.PushAsync(new DealPage(per), true); // Navigate to DealPage
        }

        private async Task loadCatAsync()
        {
            try
            {
                await this.viewModel.InitializeCatAsync(viewModel.CatId);
                this.BindingContext = this.viewModel;
                this.Title = viewModel.Category.Title;
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
        }

        private async Task loadDataAsync()
        {
            try
            {
                this.DealList.IsRefreshing = true;
                await this.viewModel.InitializeDealsAsync();
                this.BindingContext = this.viewModel;
                DealList.ItemsSource = this.viewModel.Items;
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

        private async void ListView_Refreshing(object sender, EventArgs e)
        {
            await loadDataAsync();
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
