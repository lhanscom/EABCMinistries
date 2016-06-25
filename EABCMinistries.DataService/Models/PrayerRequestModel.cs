using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmHelpers;

namespace EABCMinistries.DataService.Models
{
    public class PrayerRequestModel : ObservableObject
    {
        public string Id { get; set; }

        public string Request { get; set; }

    }
}
