using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EABCMinistries.DataService;
using EABCMinistries.Pages;
using EABCMinistries.ViewModels;
using Xamarin.Forms;

namespace EABCMinistries
{
    public class App : Application
    {
        public App()
        {            
            var navPage = new NavigationPage(new Home())
            {
                Title = "Home"
            };

            MainPage = navPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
