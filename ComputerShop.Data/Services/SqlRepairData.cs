using ComputerShop.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ComputerShop.Data.Services
{
    public class SqlRepairData : IRepairData
    {
        private readonly ComputerShopDbContext db;

        public SqlRepairData(ComputerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Repair> GetAll()
        {
            return from r in db.Repairs
                   orderby r.StartDate descending
                   select r;
        }

        public Repair Get(int id)
        {
            return db.Repairs.FirstOrDefault(r => r.Id == id);
        }

        public void Add(Repair repair)
        {
            db.Repairs.Add(repair);
            db.SaveChanges();
        }

        public void Update(Repair repair)
        {
            var entry = db.Entry(repair);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var repair = db.Repairs.Find(id);
            db.Repairs.Remove(repair);
            db.SaveChanges();
        }
    }
}
