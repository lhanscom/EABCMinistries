using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EABCMinistries.ViewModels;
using Xamarin.Forms;
using XLabs.Forms.Controls;
using EABCMinistries.DataService.Models;

namespace EABCMinistries.Pages
{
    public partial class EventList : ContentPage
    {
        protected EventListViewModel ViewModel => BindingContext as EventListViewModel;

        public EventList()
        {
            var vm = new EventListViewModel(new DataService.EventsContext());
            BindingContext = vm;
            
            var repeater = GetRepeaterView(vm);

            Content = new StackLayout
            {
                Padding = 20,
                Spacing = 5,
                Children =
                {
                    new Label
                    {
                        Text = "Events",
                        Font = Font.SystemFontOfSize(NamedSize.Large)
                    },
                    repeater
                }
            };
            vm.GetEvents.Execute(null);
        }

        private RepeaterView<EventModel> GetRepeaterView(EventListViewModel vm)
        {
            var repeater = new RepeaterView<EventModel>
            {
                ItemsSource = vm.Events,
                ItemTemplate = new DataTemplate(GetEventsTemplate)
            };

            return repeater;
        }

        private ViewCell GetEventsTemplate()
        {
            var nameLabel = new Label { Font = Font.SystemFontOfSize(NamedSize.Medium) };
            nameLabel.SetBinding(Label.TextProperty, "Name");

            var descriptionLabel = new Label { Font = Font.SystemFontOfSize(NamedSize.Small) };
            descriptionLabel.SetBinding(Label.TextProperty, "Description");

            var cell = new ViewCell
            {
                View = GetView(nameLabel, descriptionLabel)
            };

            return cell;

        }

        private static StackLayout GetView(Label nameLabel, Label descriptionLabel)
        {
            var layout = new StackLayout
            {
                Spacing = 1,
                Children =
                {
                    nameLabel,
                    descriptionLabel
                }
            };

            return layout;
        }

        private void ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //Todo implement event detail view
            //Navigation.PushAsync(new AcquaintanceDetailPage() { BindingContext = new AcquaintanceDetailViewModel((Acquaintance)e.Item) });

            ((ListView)sender).SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.GetEvents.Execute(null);
        }
    }
}
