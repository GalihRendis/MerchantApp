using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantApp.Models
{
    public class MerchantsTypeViewModel
    {
        public List<Merchants> Merchants { get; set; }
        public SelectList IndustryType { get; set; }
        public string MerchantType { get; set; }
        public string SearchString { get; set; }
    }
}
