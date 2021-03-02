using ComputerShop.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ComputerShop.Data.Services
{
    public class SqlShopData : IShopData
    {
        private readonly ComputerShopDbContext db;

        public SqlShopData(ComputerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Repair> GetRepairs()
        {
            return from r in db.Repairs
                   orderby r.StartDate descending
                   select r;
        }

        public Repair GetRepair(int id)
        {
            var entry = db.Repairs.FirstOrDefault(r => r.Id == id);
            entry.Parts = (from r in db.Parts
                           join rp in db.RepairParts on r.Id equals rp.Part.Id
                           where rp.Repair.Id == id
                           select r);
            return entry;
        }

        public void AddRepair(Repair repair)
        {
            db.Repairs.Add(repair);
            db.SaveChanges();
        }

        public void UpdateRepair(Repair repair)
        {
            var entry = db.Entry(repair);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteRepair(int id)
        {
            var repair = db.Repairs.Find(id);
            db.Repairs.Remove(repair);
            db.SaveChanges();
        }

        public IEnumerable<Part> GetParts()
        {
            return from r in db.Parts
                   orderby r.Id ascending
                   select r;
        }

        public Part GetPart(int id)
        {
            return db.Parts.FirstOrDefault(r => r.Id == id);
        }

        public void AddPart(Part part)
        {
            db.Parts.Add(part);
            db.SaveChanges();
        }

        public void UpdatePart(Part part)
        {
            var entry = db.Entry(part);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeletePart(int id)
        {
            var part = db.Parts.Find(id);
            db.Parts.Remove(part);
            db.SaveChanges();
        }
    }
}
