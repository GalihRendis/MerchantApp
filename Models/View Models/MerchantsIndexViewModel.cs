using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MerchantApp.Models
{
    public class MerchantsIndexViewModel
    {
        public List<Merchants> Merchants { get; set; }
        public SelectList IndustryType { get; set; }
        public string MerchantType { get; set; }
        public string SearchString { get; set; }
    }
}
