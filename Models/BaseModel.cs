using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MerchantApp.Models
{
    public class BaseModel
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("created_at")]
        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        [Display(Name = "Updated At")]
        public DateTime? UpdatedAt { get; set; }
    }
}
