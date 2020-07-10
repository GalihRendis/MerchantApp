using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MerchantApp.Models
{
    public class OfferCategories : BaseModel
    {
        [Column("title")]
        public string Title { get; set; }

        // Principal Key
        public List<Offers> Offers { get; set; }
    }
}
