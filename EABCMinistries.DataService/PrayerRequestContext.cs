using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EABCMinistries.DataService.Models;

namespace EABCMinistries.DataService
{
    public class PrayerRequestContext
    {
        public async Task<List<PrayerRequestModel>> GetPrayerRequests()
        {
            return new List<PrayerRequestModel>()
            {
                new PrayerRequestModel() {PrayerRequestId = 1, Request = "First Prayer Request, and it goes on for a while. This just keeps going. I can not do everything for you , and if I don't than these stones will shout.Speak to me and don't speak softly. He didn't see his brother but there was his mother.", Created = DateTime.Now},
                new PrayerRequestModel() {PrayerRequestId = 2, Request = "Second Prayer Request, and it's short.", Created = DateTime.Now}
            };
        }

    }
}
