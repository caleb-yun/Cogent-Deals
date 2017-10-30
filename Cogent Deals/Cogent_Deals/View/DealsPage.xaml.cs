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
        DealsPageViewModel viewModel;
        bool changeTitle = true;

        public DealsPage(int catId, string title = "")
        {
            if (title == "")
            {
                this.changeTitle = true;
            }
            else
            {
                this.Title = title;
                this.changeTitle = false;
            }

            this.viewModel = new DealsPageViewModel() { CatId = catId };

            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            await LoadCatAsync();
            await LoadDataAsync();
        }

        async public void OnItemTapped(object o, ItemTappedEventArgs e)
        {
            var per = e.Item as Deal;
            ((ListView)o).SelectedItem = null; // Disable selection
            await Navigation.PushAsync(new DealPage(per), true); // Navigate to DealPage
        }

        private async Task LoadCatAsync()
        {
            try
            {
                await this.viewModel.InitializeCatAsync(viewModel.CatId);
                this.BindingContext = this.viewModel;
                if (this.changeTitle)
                    this.Title = viewModel.Category.Title;
            }
            catch (InvalidOperationException ex)
            {
                //await DisplayAlert("Error", "Check your network connection.", "OK");
                return;
            }
            catch (Exception ex)
            {
                //await DisplayAlert("Error", ex.Message, "OK");
                return;
            }
        }

        private async Task LoadDataAsync()
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
                ErrorText.IsVisible = true;
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
            await LoadDataAsync();
        }

        private async void LoadMore(object sender, ItemVisibilityEventArgs e)
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
