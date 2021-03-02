using ComputerShop.Data.Models;
using System.Data.Entity;

namespace ComputerShop.Data.Services
{
    public class ComputerShopDbContext : DbContext
    {
        public DbSet<Repair> Repairs { get; set; }

        public DbSet<Part> Parts { get; set; }

        public DbSet<RepairPart> RepairParts { get; set; }
    }
}
