using Microsoft.EntityFrameworkCore;
using MerchantApp.Models;

namespace MerchantApp.Data
{
    public class MerchantAppContext : DbContext
    {
        public MerchantAppContext(DbContextOptions<MerchantAppContext> options)
                : base(options)
        {
        }
        public DbSet<Merchants> Merchants { get; set; }
        public DbSet<Offers> Offers { get; set; }
        public DbSet<OfferCategories> OfferCategories { get; set; }
    }
}
