using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.RestClient;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using Xamarin;

namespace Cogent_Deals
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public int Count = 0;

        private bool isBusy;
        public bool IsBusy
        {
            get
            {
                return isBusy;
            }
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Deal> _items;

        public ObservableCollection<Deal> Items { get; set; }

        public async Task InitializeDealsAsync()
        {
            RestClient restClient = new RestClient();

            Items = await restClient.GetAsync("http://cogentdeals.com/api/get/content/articles?catid=109&limit=15&maxsubs=10");
        }

        public async Task LoadMore(int count)
        {
            this.IsBusy = true;

            RestClient restClient = new RestClient();
            var moreItems = await restClient.GetAsync(string.Format("http://cogentdeals.com/api/get/content/articles?catid=109&limit=15&maxsubs=10&offset={0}", count * 15));

            foreach (var deal in moreItems)
            {
                Items.Add(deal);
            }

            isBusy = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}