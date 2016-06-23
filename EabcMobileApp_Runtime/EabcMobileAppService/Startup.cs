using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(EabcMobileAppService.Startup))]

namespace EabcMobileAppService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}