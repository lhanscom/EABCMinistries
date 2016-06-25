using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Tracing;
using EabcMobileAppService.Models;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Config;

namespace EabcMobileAppService.Controllers
{
    // Use the MobileAppController attribute for each ApiController you want to use  
    // from your mobile clients 
    [MobileAppController]
    public class ValuesController : ApiController
    {
        // GET api/values
        public string Get()
        {
            MobileAppSettingsDictionary settings = this.Configuration.GetMobileAppSettingsProvider().GetMobileAppSettings();
            ITraceWriter traceWriter = this.Configuration.Services.GetTraceWriter();

            string host = settings.HostName ?? "localhost";
            string greeting = "Hello from " + host;

            EabcMobileAppContext context = new EabcMobileAppContext();
            try
            {
                var item = context.PrayerRequestModels.FirstOrDefault();
                if (item != null) greeting = item.Request;
            }
            catch (Exception e)
            {
                greeting = e.ToString();
            }
            

            traceWriter.Info(greeting);
            return greeting;
        }

        // POST api/values
        public string Post()
        {
            return "Hello World!";
        }
    }
}
