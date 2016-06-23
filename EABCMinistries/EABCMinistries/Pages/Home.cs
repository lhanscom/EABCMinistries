using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using EABCMinistries.DataService;
using EABCMinistries.ViewModels;
using Xamarin.Forms;

namespace EABCMinistries.Pages
{
    public class Home : ContentPage
    {
        private Button _eventsButton;
        private Button _prayerButton;
        public Home()
        {
            InitializeComponents();
            
            var logoLayout = new AbsoluteLayout
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Black,
                Children =
                {
                    new Image
                    {
                        Source = "./Resources/drawable/logo.png",
                        Aspect = Aspect.AspectFill
                    }
                }
            };
            
            var layout = new StackLayout
            {
                BackgroundColor = Color.White,
                Children = {
                    logoLayout,
                    _eventsButton,
                    _prayerButton
                }
            };
            
            Content = layout;
        }

        private void InitializeComponents()
        {
            _eventsButton = new Button()
            {
                Text = "Events",
                BorderRadius = 5
            };
            _eventsButton.Clicked += EventsButton_Clicked;

            _prayerButton = new Button()
            {
                Text = "Prayer Requests"
            };
            _prayerButton.Clicked += PrayerButton_Clicked;
        }

        private void PrayerButton_Clicked(object sender, EventArgs e)
        {
            var context = new PrayerRequestContext();
            var vm = new PrayerRequestViewModel(context);
            var navPage = new NavigationPage(new PrayerRequests(vm)
            {
                Title = "Prayer Requests"                
            });
            Navigation.PushAsync(navPage);
        }

        private void EventsButton_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("http://www.eabcministries.com/calendar"));
            //Todo: Implement an events process? 
            //var vm = new EventListViewModel(new EventsContext());
            //var navPage = new NavigationPage(new EventList(vm)
            //{
            //    Title = "Events"
            //});
            //Navigation.PushAsync(navPage);
        }
    }
}
