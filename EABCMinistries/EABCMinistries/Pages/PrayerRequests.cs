using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using EABCMinistries.DataService;
using EABCMinistries.DataService.Models;
using EABCMinistries.ViewModels;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace EABCMinistries.Pages
{
    public class PrayerRequests : ContentPage
    {
        protected PrayerRequestViewModel ViewModel => BindingContext as PrayerRequestViewModel;

        public PrayerRequests(PrayerRequestViewModel vm)
        {
            
            BindingContext = vm;
            ToolbarItems.Add(new ToolbarItem("New", null, async () => await NewPrayerRequest()));
            Content = new StackLayout
            {                
                Children = {
                    new Label { Text = "Prayer Requests" },
                    GetRepeaterView()
                }
            };
            ViewModel.GetPrayerRequests.Execute(null);
        }

        private async Task NewPrayerRequest()
        {
            var prayerRequest = new PrayerRequestModel() {Request = "New Request"};
            await ViewModel.InsertPrayerRequest(prayerRequest);

            //ViewModel.GetPrayerRequests.Execute(null);
        }

        private RepeaterView<PrayerRequestModel> GetRepeaterView()
        {
            var repeater = new RepeaterView<PrayerRequestModel>
            {
                ItemsSource = ViewModel.PrayerRequestCollection,
                ItemTemplate = new DataTemplate(GetTemplate)
            };

            return repeater;
        }

        private ViewCell GetTemplate()
        {
            var requestDateLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                TextColor = Color.White
            };
            requestDateLabel.SetBinding(Label.TextProperty, "CreatedAt", BindingMode.Default, null, "{0:dddd MMMM dd hh:mm tt}");

            var requestLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                LineBreakMode = LineBreakMode.WordWrap,
                TextColor = Color.White

            };
            requestLabel.SetBinding(Label.TextProperty, "Request");

            var cell = new ViewCell
            {
                View = GetView(requestDateLabel, requestLabel),
                Height = 100D
            };

            return cell;

        }

        private static View GetView(Label requestDateLabel, Label requestLabel)
        {
            var layout = new StackLayout
            {
                Spacing = 1,
                Padding = new Thickness(1D, 10D, 1D, 10D)
            };
            layout.Children.Add(requestDateLabel);
            layout.Children.Add(requestLabel);

            return layout;
        }
    }
}
