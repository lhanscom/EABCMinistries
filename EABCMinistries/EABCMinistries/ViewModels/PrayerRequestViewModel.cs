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
    public class PrayerRequestViewModel : BaseNavigationViewModel
    {
        private readonly PrayerRequestContext _prayerRequestContext;
        private Command _getPrayerRequests;

        public PrayerRequestViewModel(PrayerRequestContext prayerRequestContext)
        {
            _prayerRequestContext = prayerRequestContext;
            PrayerRequestCollection = new ObservableRangeCollection<PrayerRequestModel>();
            MainText = "Prayer Requests";
        }

        public ObservableRangeCollection<PrayerRequestModel> PrayerRequestCollection { get; set; }

        public string MainText { get; set; }

        public Command GetPrayerRequests => _getPrayerRequests ?? (_getPrayerRequests = new Command(async () => await ExecuteGetPrayerRequests()));

        private async Task ExecuteGetPrayerRequests()
        {
            if (PrayerRequestCollection.Count >= 1) return;

            GetPrayerRequests.ChangeCanExecute();

            await FetchPrayerRequests();

            GetPrayerRequests.ChangeCanExecute();
        }

        private async Task FetchPrayerRequests()
        {
            IsBusy = true;

            var prayerRequests = await _prayerRequestContext.GetPrayerRequests();

            PrayerRequestCollection.Clear();

            if (prayerRequests.Count != 0)
                PrayerRequestCollection.AddRange(prayerRequests);

            IsBusy = false;
        }
    }
}
