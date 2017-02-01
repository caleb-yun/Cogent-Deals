﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.RestClient;
using Xamarin.Forms;
using System.Runtime.CompilerServices;

namespace Cogent_Deals
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
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

        private List<Deal> _items;

        public List<Deal> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public async Task InitializeDealsAsync()
        {
            RestClient restClient = new RestClient();

            var dealList = await restClient.GetAsync("http://cogentdeals.com/api/get/content/articles?catid=109&limit=10&maxsubs=10");

            Items = dealList;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}