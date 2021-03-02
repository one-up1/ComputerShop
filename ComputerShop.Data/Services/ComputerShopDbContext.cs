using ComputerShop.Data.Models;
using System.Data.Entity;

namespace ComputerShop.Data.Services
{
    public class ComputerShopDbContext : DbContext
    {
        public DbSet<Repair> Repairs { get; set; }

        public DbSet<Part> Parts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Repair>()
                        .HasMany<Part>(r => r.Parts)
                        .WithMany(p => p.Repairs)
                        .Map(rp =>
                                {
                                    rp.MapLeftKey("Repair_Id");
                                    rp.MapRightKey("Part_Id");
                                    rp.ToTable("RepairParts");
                                });
        }
    }
}
