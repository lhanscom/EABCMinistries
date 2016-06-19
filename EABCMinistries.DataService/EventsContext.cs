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
                new EventModel() {Name = "First Event", Description = "First Event Description", Start = new DateTime(2016,7,12)},
                new EventModel() {Name = "Second Event", Description = "Second Event Description", Start = new DateTime(2016,8,12)}
            };
        }
    }
}
