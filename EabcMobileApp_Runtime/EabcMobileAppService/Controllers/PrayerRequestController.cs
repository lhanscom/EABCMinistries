using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using EabcMobileAppService.DataObjects;
using EabcMobileAppService.Models;
using Microsoft.Azure.Mobile.Server;

namespace EabcMobileAppService.Controllers
{
    public class PrayerRequestController : TableController<PrayerRequestModel>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            EabcMobileAppContext context = new EabcMobileAppContext();
            DomainManager = new EntityDomainManager<PrayerRequestModel>(context, Request);
        }

        // GET tables/PrayerRequestModel
        public IQueryable<PrayerRequestModel> GetAllPrayerRequestModels()
        {
            return Query();
        }

        // GET tables/PrayerRequestModel/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<PrayerRequestModel> GetPrayerRequestModel(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/PrayerRequestModel/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<PrayerRequestModel> PatchPrayerRequestModel(string id, Delta<PrayerRequestModel> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/PrayerRequestModel
        public async Task<IHttpActionResult> PostPrayerRequestModel(PrayerRequestModel item)
        {
            PrayerRequestModel current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/PrayerRequestModel/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeletePrayerRequestModel(string id)
        {
            return DeleteAsync(id);
        }
    }
}