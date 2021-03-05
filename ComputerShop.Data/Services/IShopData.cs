using ComputerShop.Data.Models;
using System.Collections.Generic;

namespace ComputerShop.Data.Services
{
    public interface IShopData
    {
        IEnumerable<Repair> GetRepairs();

        Repair GetRepair(int id);

        void AddRepair(Repair repair);

        void UpdateRepair(Repair repair);

        void DeleteRepair(int id);

        IEnumerable<Part> GetParts();

        Part GetPart(int id);

        void AddPart(Part repair);

        void UpdatePart(Part repair);

        void DeletePart(int id);

        IEnumerable<RepairPart> GetRepairParts(int repairId);

        void AddRepairPart(int repairId, int partId);

        int DeleteRepairPart(int id);
    }
}
