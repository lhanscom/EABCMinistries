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
        public Home()
        {
            var eventsButton = new Button()
            {
                Text = "Events"
            };
            eventsButton.Clicked += EventsButton_Clicked;

            var prayerButton = new Button()
            {
                Text = "Prayer Requests"
            };
            prayerButton.Clicked += PrayerButton_Clicked;

            Content = new StackLayout
            {
                Children = {
                    new Label
                    {
                        Text = "Welcome to EABC",
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
                    },
                    eventsButton,
                    prayerButton
                }
            };
        }

        private void PrayerButton_Clicked(object sender, EventArgs e)
        {
            var vm = new PrayerRequestViewModel(new PrayerRequestContext());
            var navPage = new NavigationPage(new PrayerRequests(vm)
            {
                Title = "Prayer Requests"
            });
            Navigation.PushAsync(navPage);
        }

        private void EventsButton_Clicked(object sender, EventArgs e)
        {
            var vm = new EventListViewModel(new EventsContext());
            var navPage = new NavigationPage(new EventList(vm)
            {
                Title = "Events"
            });
            Navigation.PushAsync(navPage);
        }
    }
}
