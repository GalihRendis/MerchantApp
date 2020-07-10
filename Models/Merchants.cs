using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MerchantApp.Models
{
    public class Merchants : BaseModel
    {
        [Column("name")]
        public string Name { get; set; }
        [Column("official_url")]
        [Display(Name = "Official URL")]
        public string OfficialUrl { get; set; }
        [Column("sender_email")]
        [Display(Name = "Sender Email")]
        public string SenderEmail { get; set; }
        [Column("subdomain")]
        public string Subdomain { get; set; }
        [Column("industry_type")]
        [Display(Name = "Industry Type")]
        public string IndustryType { get; set; }

        // Principal Key
        public List<Offers> Offers { get; set; }
    }
}