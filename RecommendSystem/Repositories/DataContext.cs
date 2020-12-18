using Microsoft.EntityFrameworkCore;
using RecommendSystem.Models;

namespace RecommendSystem.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions opts) : base(opts)
        {
            
        }

        public DbSet<Item> Item { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<ItemReview> ItemReview { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Review>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<ItemReview>()
                .HasKey(x => new {x.ItemId, x.ReviewId});
            modelBuilder.Entity<ItemReview>()
                .HasOne(ir => ir.Item)
                .WithMany(i => i.ItemReviews)
                .HasForeignKey(nameof(Models.ItemReview.ItemId));
            modelBuilder.Entity<ItemReview>()
                .HasOne(ir => ir.Review)
                .WithMany(r => r.ItemReviews)
                .HasForeignKey(nameof(Models.ItemReview.ReviewId));
        }
    }
}