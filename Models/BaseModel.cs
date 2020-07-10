using System;
using System.ComponentModel.DataAnnotations.Schema;

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
