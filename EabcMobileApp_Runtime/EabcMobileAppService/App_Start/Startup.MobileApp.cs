using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using EabcMobileAppService.DataObjects;
using EabcMobileAppService.Models;
using Owin;

namespace EabcMobileAppService
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            //For more information on Web API tracing, see http://go.microsoft.com/fwlink/?LinkId=620686 
            config.EnableSystemDiagnosticsTracing();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

            // Use Entity Framework Code First to create database tables based on your DbContext
            Database.SetInitializer(new EabcMobileAppInitializer());

            // To prevent Entity Framework from modifying your database schema, use a null database initializer
            // Database.SetInitializer<EabcMobileAppContext>(null);

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                // This middleware is intended to be used locally for debugging. By default, HostName will
                // only have a value when running in an App Service application.
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                    ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                    ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                    TokenHandler = config.GetAppServiceTokenHandler()
                });
            }
            app.UseWebApi(config);
        }
    }

    public class EabcMobileAppInitializer : CreateDatabaseIfNotExists<EabcMobileAppContext> //DropCreateDatabaseAlways<EabcMobileAppContext>
    {
        protected override void Seed(EabcMobileAppContext context)
        {
            List<TodoItem> todoItems = new List<TodoItem>
            {
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "First item", Complete = false },
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Second item", Complete = false },
            };

            foreach (TodoItem todoItem in todoItems)
            {
                context.Set<TodoItem>().Add(todoItem);
            }

            var prayerItems = new List<PrayerRequestModel>()
            {
                new PrayerRequestModel() {PrayerRequestId = 1, Request = "First Prayer Request, and it goes on for a while. This just keeps going. I can not do everything for you , and if I don't than these stones will shout.Speak to me and don't speak softly. He didn't see his brother but there was his mother.", Created = DateTime.Now},
                new PrayerRequestModel() {PrayerRequestId = 2, Request = "Second Prayer Request, and it's short.", Created = DateTime.Now}
            };

            foreach (var prayerItem in prayerItems)
            {
                context.Set<PrayerRequestModel>().Add(prayerItem);
            }


            base.Seed(context);
        }
    }
}

