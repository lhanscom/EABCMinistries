using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Azure.Mobile.Server;

namespace EabcMobileAppService.DataObjects
{
    public class PrayerRequestModel : EntityData
    {
        [Key]
        public int PrayerRequestId { get; set; }

        public string Request { get; set; }

        public DateTime Created { get; set; }
    }
}
