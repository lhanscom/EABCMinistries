using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EABCMinistries.ViewModels;
using Xamarin.Forms;

namespace EABCMinistries.Pages
{
    public partial class EventList : ContentPage
    {
        protected EventListViewModel ViewModel => BindingContext as EventListViewModel;

        public EventList()
        {
            InitializeComponent();
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
