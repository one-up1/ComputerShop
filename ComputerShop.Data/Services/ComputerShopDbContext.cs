using ComputerShop.Data.Models;
using System.Data.Entity;

namespace ComputerShop.Data.Services
{
    public class ComputerShopDbContext : DbContext
    {
        public DbSet<Repair> Repairs { get; set; }

        public DbSet<Part> Parts { get; set; }

        public DbSet<RepairPart> RepairParts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RepairPart>()
                .HasRequired(rp => rp.Repair)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<RepairPart>()
                .HasRequired(rp => rp.Part)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}
