using ComputerShop.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
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
            return db.Repairs.FirstOrDefault(r => r.Id == id);
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
                   orderby r.Name ascending
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

        public IEnumerable<RepairPart> GetRepairParts(int repairId)
        {
            return db.RepairParts
                .Where(rp => rp.Repair.Id == repairId)
                .Include("Part");
        }

        public int GetRepairPartsCount()
        {
            return db.RepairParts.Count();
        }

        public double GetRepairPartsPriceSum()
        {
            return db.RepairParts.Sum(rp => rp.Part.Price);
        }

        public double GetRepairPartsPriceSum(int repairId)
        {
            return db.RepairParts
                .Where(rp => rp.Repair.Id == repairId)
                .Sum(rp => rp.Part.Price);
        }

        public void AddRepairPart(int repairId, int partId)
        {
            /*var repairPart = new RepairPart();

            repairPart.Repair = new Repair();
            repairPart.Repair.Id = repairId;

            repairPart.Part = new Part();
            repairPart.Part.Id = partId;

            db.RepairParts.Add(repairPart);
            db.SaveChanges();*/

            db.Database.ExecuteSqlCommand(
                "INSERT INTO RepairParts (Repair_Id, Part_Id) VALUES (@repairId, @partId)",
                new SqlParameter("@repairId", repairId),
                new SqlParameter("@partId", partId));
        }

        public int DeleteRepairPart(int id)
        {
            var repairPart = db.RepairParts
                .Include(rp => rp.Repair)
                .SingleOrDefault(rp => rp.Id == id);
            int repairId = repairPart.Repair.Id;

            db.RepairParts.Remove(repairPart);
            db.SaveChanges();

            return repairId;
        }
    }
}
