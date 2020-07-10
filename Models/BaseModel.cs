using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantApp.Models
{
    public class BaseModel
    {
        static String now = DateTime.Now.ToString("dd MMMM yyyy");
        [Column("id")]
        public int Id { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Parse(now);
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Parse(now);
    }
}
