using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FFImageLoading.Forms.Droid;
using Plugin.LocalNotifications;
using Android.Gms.Common;

using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;

namespace Cogent_Deals.Droid
{
    [Activity(Label = "Cogent Deals", Icon = "@drawable/icon", Theme = "@style/splashscreen", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        const string TAG = "MainActivity";

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            CachedImageRenderer.Init();

            base.SetTheme(Resource.Style.MainTheme);

            base.OnCreate(bundle);

            LocalNotificationsImplementation.NotificationIconId = Resource.Drawable.notification;

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            // Handle notification intents
            if (Intent.Extras != null)
            {
                foreach (var key in Intent.Extras.KeySet())
                {
                    var value = Intent.Extras.GetString(key);
                    Log.Debug(TAG, "Key: {0} Value: {1}", key, value);
                }
            }

            DebugAlert(PlayServicesAvailable());

            Log.Debug(TAG, "InstanceID token: " + FirebaseInstanceId.Instance.Token);
            DebugAlert(FirebaseInstanceId.Instance.Token);
        }

        public string PlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                    return GoogleApiAvailability.Instance.GetErrorString(resultCode);
                else
                {
                    Finish();
                    return "This device is not supported";
                }
            }
            else
            {
                return "Google Play Services is available.";
            }

            
        }

        private void DebugAlert(string msg)
        {
            AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
            alertDialog.SetTitle("Debug");
            alertDialog.SetMessage(msg);
            alertDialog.SetNeutralButton("OK", delegate
            {
                alertDialog.Dispose();
            });
            RunOnUiThread(() => {
                alertDialog.Show();
            });
        }

    }
}

