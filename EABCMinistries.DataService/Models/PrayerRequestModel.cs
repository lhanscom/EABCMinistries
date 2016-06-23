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
        public int id { get; set; }

        public int PrayerRequestId { get; set; }

        public string Request { get; set; }

        public DateTime Created { get; set; }
    }
}
