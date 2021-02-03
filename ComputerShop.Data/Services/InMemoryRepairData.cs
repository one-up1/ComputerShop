using ComputerShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerShop.Data.Services
{
    public class InMemoryRepairData : IRepairData
    {
        private List<Repair> repairs;

        public InMemoryRepairData()
        {
            repairs = new List<Repair>()
            {
                new Repair { Id = 1, StartDate = new DateTime(2020, 12, 21), EndDate = new DateTime(2020, 12, 28), Status = Status.Completed, Description = "HDD crash" },
                new Repair { Id = 2, StartDate = new DateTime(2021, 1, 2), EndDate = new DateTime(2021, 3, 1), Status = Status.InProgress, Description = "Rook" }
            };
        }

        public IEnumerable<Repair> GetAll()
        {
            return repairs.OrderBy(r => r.StartDate);
        }

        public Repair Get(int id)
        {
            return repairs.FirstOrDefault(r => r.Id == id);
        }

        public void Add(Repair repair)
        {
            repairs.Add(repair);
            repair.Id = repairs.Max(r => r.Id) + 1;
        }

        public void Update(Repair repair)
        {
            var existing = Get(repair.Id);
            if (existing != null)
            {
                existing.StartDate = repair.StartDate;
                existing.EndDate = repair.EndDate;
                existing.Status = repair.Status;
                existing.Description = repair.Description;
            }
        }
    }
}
