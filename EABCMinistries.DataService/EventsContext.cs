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
                new EventModel() {Name = "First Event", Description = "<div><b>First Event Description</b></div>", Start = new DateTime(2016,7,12)},
                new EventModel() {Name = "Second Event", Description = "<div><b>Second Event Description</b></div>", Start = new DateTime(2016,8,12)}
            };
        }
    }
}
