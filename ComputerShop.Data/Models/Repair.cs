using System;

namespace ComputerShop.Data.Models
{
    public class Repair
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }
        public string Description { get; set; }
    }
}
