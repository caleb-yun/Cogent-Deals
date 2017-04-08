using Xamarin.Forms;

namespace Cogent_Deals
{
    public class CardView : Frame
    {
        public CardView()
        {
            Padding = 0;
            if (Device.OS == TargetPlatform.iOS)
            {
                HasShadow = false;
                OutlineColor = Color.Transparent;
                BackgroundColor = Color.Transparent;
            }
        }
    }
}

