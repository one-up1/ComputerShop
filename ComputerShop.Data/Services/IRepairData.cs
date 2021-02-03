using ComputerShop.Data.Models;
using System.Collections.Generic;

namespace ComputerShop.Data.Services
{
    public interface IRepairData
    {
        IEnumerable<Repair> GetAll();

        Repair Get(int id);

        void Add(Repair repair);

        void Update(Repair repair);
    }
}
