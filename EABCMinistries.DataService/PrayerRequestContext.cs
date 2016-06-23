using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EABCMinistries.DataService.Models;
using Microsoft.WindowsAzure.MobileServices;

namespace EABCMinistries.DataService
{
    public class PrayerRequestContext
    {
        private readonly MobileServiceClient _client;

        const string applicationURL = @"https://eabcmobileapp.azurewebsites.net";

        public PrayerRequestContext()
        {
            _client = new MobileServiceClient(applicationURL);
        }

        public async Task<List<PrayerRequestModel>> GetPrayerRequests()
        {
            //var todoTable = _client.GetSyncTable<ToDoItem>();
            //var item = new ToDoItem
            //{
            //    Text =
            //        "First Prayer Request, and it goes on for a while. This just keeps going. I can not do everything for you , and if I don't than these stones will shout.Speak to me and don't speak softly. He didn't see his brother but there was his mother."
            //};

            //await _client.GetTable<ToDoItem>().InsertAsync(item);

            //var items = await _client.GetTable<ToDoItem>().ToListAsync();
            //var result =
            //    items.Select(
            //        todoItem => new PrayerRequestModel() {PrayerRequestId = todoItem.Id, Request = todoItem.Text})
            //        .ToList();
            return await _client.GetTable<PrayerRequestModel>().ToListAsync();

            //return new List<PrayerRequestModel>()
            //{
            //    new PrayerRequestModel() {PrayerRequestId = 1, Request = "First Prayer Request, and it goes on for a while. This just keeps going. I can not do everything for you , and if I don't than these stones will shout.Speak to me and don't speak softly. He didn't see his brother but there was his mother.", Created = DateTime.Now},
            //    new PrayerRequestModel() {PrayerRequestId = 2, Request = "Second Prayer Request, and it's short.", Created = DateTime.Now}
            //};
        }

        public async Task InsertPrayerRequest(PrayerRequestModel prayerRequest)
        {
            //var todoItem = new ToDoItem {Text = prayerRequest.Request};

            //await _client.GetTable<ToDoItem>().InsertAsync(todoItem);

            await _client.GetTable<PrayerRequestModel>().InsertAsync(prayerRequest);
        }


    }
    public class ToDoItem
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }
}
