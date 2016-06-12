using System;
using MvvmHelpers;

namespace EABCMinistries.DataService.Models
{
    public class EventModel : ObservableObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }

    }
}