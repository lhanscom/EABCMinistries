using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EABCMinistries.DataService;
using EABCMinistries.DataService.Models;
using MvvmHelpers;
using Xamarin.Forms;

namespace EABCMinistries.ViewModels
{
    public class EventListViewModel : BaseNavigationViewModel
    {
        private readonly EventsContext _eventsContext;
        private Command _getEvents;

        public EventListViewModel(EventsContext eventsContext)
        {
            _eventsContext = eventsContext;
            Events = new ObservableRangeCollection<EventModel>();
            MainText = "Upcoming Events";
        }

        public ObservableRangeCollection<EventModel> Events { get; set; }

        public string MainText { get; set; }

        public Command GetEvents => _getEvents ?? (_getEvents = new Command(async () => await ExecuteGetEventsCommand()));

        private  async Task ExecuteGetEventsCommand()
        {
            if (Events.Count >= 1) return;

            GetEvents.ChangeCanExecute();

            await FetchEvents();

            GetEvents.ChangeCanExecute();
        }

        private async Task FetchEvents()
        {
            IsBusy = true;

            var events = await _eventsContext.GetUpcoming();

            Events.Clear();

            if (events.Count != 0)
                Events.AddRange(events);

            IsBusy = false;
        }
    }
}
