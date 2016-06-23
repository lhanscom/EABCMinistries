using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using EABCMinistries.DataService.Models;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Xamarin.Auth;

namespace EABCMinistries.DataService
{
    public class EventsContext
    {
        private string[] _scopes = { CalendarService.Scope.CalendarReadonly };
        private string _applicationName = "EABC.Ministries";

        public async Task<List<EventModel>> GetUpcoming()
        {
            return new List<EventModel>()
            {
                new EventModel() {Name = "First Event", Description = "First Event Description, and it goes on for a while. This just keeps going. I can not do everything for you , and if I don't than these stones will shout.Speak to me and don't speak softly. He didn't see his brother but there was his mother.", Start = new DateTime(2016,7,12,13,30,0)},
                new EventModel() {Name = "Second Event", Description = "Second Event Description", Start = new DateTime(2016,8,12,18,0,0)},
                new EventModel() {Name = "Third Event", Description = "First Event Description, and it goes on for a while. This just keeps going. I can not do everything for you , and if I don't than these stones will shout.Speak to me and don't speak softly. He didn't see his brother but there was his mother.", Start = new DateTime(2016,7,12,13,30,0)},
                new EventModel() {Name = "Forth Event", Description = "Second Event Description", Start = new DateTime(2016,8,12,18,0,0)},
                new EventModel() {Name = "Fifth Event", Description = "First Event Description, and it goes on for a while. This just keeps going. I can not do everything for you , and if I don't than these stones will shout.Speak to me and don't speak softly. He didn't see his brother but there was his mother.", Start = new DateTime(2016,7,12,13,30,0)},
                new EventModel() {Name = "Sixth Event", Description = "Second Event Description", Start = new DateTime(2016,8,12,18,0,0)}
            };
        }
        //TODO: Make credentials work for Google API access
        //private UserCredential GetCalendarCredential()
        //{
        //    Xamarin.Auth.OAuth2Request request = new OAuth2Request();
        //    UserCredential credential;
        //    var autherizer =
        //        new Google.Apis.Auth.OAuth2.Web.AuthorizationCodeWebApp(
        //            new AuthorizationCodeFlow(new AuthorizationCodeFlow.Initializer("", "")), "", "");

            
        //    using (var stream =
        //        new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
        //    {
        //        string credPath = System.Environment.GetFolderPath(
        //            System.Environment.SpecialFolder.Personal);
        //        credPath = Path.Combine(credPath, ".credentials/calendar-dotnet-quickstart.json");

        //        var secrets = new GoogleClientSecrets
        //        {
        //            Secrets =
        //            {
        //                ClientId = "137118182024-dtepjdqap3m9d1hsb89e0a8qf610if44.apps.googleusercontent.com" //,
        //                //ClientSecret = ""
        //            }
        //        };
        //        credential = Google.Apis.Auth.OAuth2.
        //            /*
        //        credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
        //            secrets.Secrets,
        //            _scopes,
        //            "user",
        //            CancellationToken.None,
        //            new FileDataStore(credPath, true)).Result;
        //        Console.WriteLine("Credential file saved to: " + credPath);
        //        */
        //    }

        //    var auth = new Google.Apis.Authentication.OAuth2.GoogleAuthenticator(ClientID,
        //                    new Uri("http://example.com/callback"),
        //                    Google.Apis.Tasks.v1.TasksService.Scopes.Tasks.GetStringValue());

        //    // When we're authenticated, we'll show the tasks from the default list
        //    Action showTasks = () =>
        //    {
        //        var service = new Google.Apis.Tasks.v1.TasksService(auth);

        //        // get the tasks from the default task list
        //        var tasks = service.Tasks.List("@default").Fetch();
        //        foreach (var task in tasks.Items)
        //            Console.WriteLine(task.Title);
        //    };

        //    // We don't want to have to login every time, so we'll use the Xamarin.Auth AccountStore
        //    AccountStore store = AccountStore.Create(this);
        //    Account savedAccount = store.FindAccountsForService("google").FirstOrDefault();
        //    if (savedAccount != null)
        //    {
        //        this.auth.Account = savedAccount;
        //        showTasks();
        //    }
        //    else
        //    {
        //        this.auth.Completed += (sender, args) =>
        //        {
        //            if (args.IsAuthenticated)
        //            {
        //                // Save the account for the future
        //                store.Save(args.Account, "google");
        //                RunOnUiThread(showTasks);
        //            }
        //            else // Authentication failed
        //                Toast.MakeText(this, "Error logging in", ToastLength.Long).Show();
        //        };

        //        Intent authIntent = this.auth.GetUI(this);
        //        StartActivity(authIntent);
        //    }

        //    Intent loginIntent = auth.GetUI(this);
        //    StartActivity(loginIntent);
        //}
    }
}
