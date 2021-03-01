namespace ComputerShop.Data.Models
{
    public class RepairPart
    {
        public int Id { get; set; }

        public Repair Repair { get; set; }

        public Part Part { get; set; }
    }
}
