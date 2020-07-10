using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MerchantApp.Models
{
    public class Merchants
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public String Name { get; set; }
        [Column("official_url")]
        [Display(Name = "Official URL")]
        public String OfficialUrl { get; set; }
        [Column("sender_email")]
        [Display(Name = "Sender Email")]
        public String SenderEmail { get; set; }
        [Column("subdomain")]
        public String Subdomain { get; set; }
        [Column("industry_type")]
        [Display(Name = "Industry Type")]
        public String IndustryType { get; set; }
    }
}