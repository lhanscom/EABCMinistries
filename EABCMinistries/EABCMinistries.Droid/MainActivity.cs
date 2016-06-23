using System;

using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.WindowsAzure.MobileServices;

namespace EABCMinistries.Droid
{
    
    [Activity(Label = "EABCMinistries", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        const string GoogleCalendarApiKey = "AIzaSyCXC_iAIUe0HIKqxjUud8MQrj1IKmKL1bw";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            CurrentPlatform.Init();
            Title = "EABC Ministries";
            TitleColor = Color.Red;

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

