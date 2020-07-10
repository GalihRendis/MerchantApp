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
    }
}
