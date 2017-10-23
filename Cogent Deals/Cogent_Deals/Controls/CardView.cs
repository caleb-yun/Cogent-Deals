using Xamarin.Forms;

namespace Cogent_Deals
{
    public class CardView : Frame
    {
        public CardView()
        {
            Padding = 0;
            if (Device.RuntimePlatform == Device.iOS)
            {
                HasShadow = true;
                CornerRadius = 2;
                //OutlineColor = Color.Silver;
                //BackgroundColor = Color.Transparent;
            }
        }
    }
}

