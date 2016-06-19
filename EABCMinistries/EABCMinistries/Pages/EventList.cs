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

        public EventList(EventListViewModel vm)
        {
            BindingContext = vm;
            BackgroundColor = Color.Red.WithLuminosity(0.9);

            this.IsBusy = true;

            //var vm = new EventListViewModel(new DataService.EventsContext());
            //BindingContext = vm;
            
            var repeater = GetRepeaterView();

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
            ViewModel.GetEvents.Execute(null);
            this.IsBusy = false;
        }

        private View GetRepeaterView()
        {
            var repeater = new RepeaterView<EventModel>
            {
                ItemsSource = ViewModel.Events,
                ItemTemplate = new DataTemplate(GetEventsTemplate)
            };

            var scrollView = new ScrollView()
            {
                Content = repeater
            };

            return scrollView;
        }

        private ViewCell GetEventsTemplate()
        {
            var nameLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                LineBreakMode = LineBreakMode.TailTruncation,
                TextColor = Color.Black
            };
            nameLabel.SetBinding(Label.TextProperty, "Name");
            

            var startDateLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                TextColor = Color.Black
            };
            startDateLabel.SetBinding(Label.TextProperty, "Start", BindingMode.Default, null, "{0:dddd MMMM dd hh:mm tt}");

            var descriptionLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                LineBreakMode = LineBreakMode.WordWrap,
                TextColor = Color.Black
            
            };
            descriptionLabel.SetBinding(Label.TextProperty, "Description");

            var cell = new ViewCell
            {
                View = GetView(nameLabel, startDateLabel, descriptionLabel),
                Height = 100D
            };

            return cell;

        }

        private static View GetView(Label nameLabel, Label startDateLabel, Label descriptionLabel)
        {
            var titleLayout = new AbsoluteLayout();
            titleLayout.Children.Add(nameLabel, new Rectangle(0F, 0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize), AbsoluteLayoutFlags.PositionProportional);
            

            //return absLayout;
            var dateLayout = new AbsoluteLayout();
            dateLayout.Children.Add(startDateLabel, new Rectangle(1F, 0F, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize), AbsoluteLayoutFlags.PositionProportional);

            var layout = new StackLayout
            {
                Spacing = 1,
                Padding = new Thickness(1D, 10D, 1D, 10D)
            };
            layout.Children.Add(titleLayout);
            layout.Children.Add(dateLayout);
            layout.Children.Add(descriptionLabel);


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

        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }
    }
}
