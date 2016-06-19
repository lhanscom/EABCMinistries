using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using EABCMinistries.DataService.Models;

namespace EABCMinistries.DataService
{
    public class EventsContext
    {
        public async Task<List<EventModel>> GetUpcoming()
        {
            return new List<EventModel>()
            {
                new EventModel() {Name = "First Event", Description = "First Event Description, and it goes on for a while. This just keeps going. I can not do everything for you , and if I don't than these stones will shout.Speak to me and don't speak softly. He didn't see his brother but there was his mother.", Start = new DateTime(2016,7,12,13,30,0)},
                new EventModel() {Name = "Second Event", Description = "Second Event Description", Start = new DateTime(2016,8,12,18,0,0)}
            };
        }
    }
}
