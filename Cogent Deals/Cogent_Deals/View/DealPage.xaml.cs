using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Cogent_Deals
{
    public partial class DealPage : ContentPage
    {
        private DealPageViewModel viewModel;

        public DealPage(Deal deal)
        {
            InitializeComponent();

            BindingContext = viewModel = new DealPageViewModel(deal);
        }

        public void OnClicked(object sender, EventArgs args)
        {
            Device.OpenUri(new Uri(viewModel.Deal.Fields.ItemUrl));
        }
    }
}
