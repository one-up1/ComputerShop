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
                new Repair { Id = 2, StartDate = new DateTime(2021, 01, 02), Status = Status.InProgress, Description = "Rook" }
            };
        }

        public IEnumerable<Repair> GetAll()
        {
            return repairs.OrderBy(r => r.StartDate);
        }
    }
}
