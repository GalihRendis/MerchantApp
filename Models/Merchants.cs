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

        [Column("checkout_type")]
        [Display(Name = "Checkout Type")]
        public string CheckoutType { get; set; }

        // Principal Key
        public List<Offers> Offers { get; set; }
    }
}