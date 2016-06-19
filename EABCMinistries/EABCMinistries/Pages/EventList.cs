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
        private Label _nameLabel;
        private Label _startDateLabel;
        private Label _descriptionLabel;
        private Button _detailsButton;

        protected EventListViewModel ViewModel => BindingContext as EventListViewModel;

        public EventList(EventListViewModel vm)
        {
            BindingContext = vm;
            BackgroundColor = Color.Black;

            this.IsBusy = true;
           
            var repeater = GetRepeaterView();

            Content = new StackLayout
            {
                Padding = 20,
                Spacing = 5,
                Children =
                {
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
            _nameLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                LineBreakMode = LineBreakMode.TailTruncation,
                TextColor = Color.White
            };
            _nameLabel.SetBinding(Label.TextProperty, "Name");            

            _startDateLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                TextColor = Color.White
            };
            _startDateLabel.SetBinding(Label.TextProperty, "Start", BindingMode.Default, null, "{0:dddd MMMM dd hh:mm tt}");

            _descriptionLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                LineBreakMode = LineBreakMode.WordWrap,
                TextColor = Color.White

            };
            _descriptionLabel.SetBinding(Label.TextProperty, "Description");

            _detailsButton = new Button
            {
                Text = "...",
                BackgroundColor = Color.Transparent,
                TextColor = Color.White,                
                BorderWidth = 0,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button))
            };

            _detailsButton.Clicked += DetailsButton_Clicked;

            var cell = new ViewCell
            {
                View = GetView(),
                Height = 100D
            };            

            return cell;

        }

        private View GetView()
        {
            var titleLayout = new AbsoluteLayout();
            titleLayout.Children.Add(_nameLabel, new Rectangle(0F, 0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize), AbsoluteLayoutFlags.PositionProportional);
            titleLayout.Children.Add(_detailsButton, new Rectangle(1, 0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize), AbsoluteLayoutFlags.PositionProportional);

            var dateLayout = new AbsoluteLayout();
            dateLayout.Children.Add(_startDateLabel, new Rectangle(1F, 0F, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize), AbsoluteLayoutFlags.PositionProportional);

            var layout = new StackLayout
            {
                Spacing = 1,
                Padding = new Thickness(1D, 10D, 1D, 10D)
            };
            layout.Children.Add(titleLayout);
            layout.Children.Add(dateLayout);
            layout.Children.Add(_descriptionLabel);

            return layout;
        }

        private void DetailsButton_Clicked(object sender, EventArgs e)
        {
            ViewModel.Events.Add(new EventModel() { Description = "New Description", Name = "New Name", Start = DateTime.Now });
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
