using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cogent_Deals
{
    class DealPageViewModel
    {
        public Deal Deal { get; set; }

        public DealPageViewModel(Deal deal)
        {
            this.Deal = deal;
        }
    }
}
