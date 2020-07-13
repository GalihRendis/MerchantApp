using MerchantApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MerchantApp.Data
{
    public class MerchantAppContext : DbContext
    {
        public MerchantAppContext(DbContextOptions<MerchantAppContext> options)
                : base(options)
        {
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var AddedEntities = ChangeTracker.Entries()
                   .Where(E => E.State == EntityState.Added)
                   .ToList();

            AddedEntities.ForEach(E =>
            {
                E.Property("CreatedAt").CurrentValue = DateTime.Now;
            });

            var EditedEntities = ChangeTracker.Entries()
                .Where(E => E.State == EntityState.Modified)
                .ToList();

            EditedEntities.ForEach(E =>
            {
                E.Property("UpdatedAt").CurrentValue = DateTime.Now;
            });

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public DbSet<Merchants> Merchants { get; set; }
        public DbSet<Offers> Offers { get; set; }
        public DbSet<OfferCategories> OfferCategories { get; set; }
    }
}
