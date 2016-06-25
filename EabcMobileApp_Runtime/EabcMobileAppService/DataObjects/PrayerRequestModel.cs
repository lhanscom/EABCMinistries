using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Azure.Mobile.Server;

namespace EabcMobileAppService.DataObjects
{
    [Table("PrayerRequestModel")]
    public class PrayerRequestModel : EntityData
    {
        public string Request { get; set; }

        public DateTime Created { get; set; }
    }
}
