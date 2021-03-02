using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComputerShop.Data.Models
{
    public class Part
    {
        public int Id { get; set; }

        [Display(Name = "Naam")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Naam is verplicht")]
        public string Name { get; set; }

        [Display(Name = "Prijs")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Prijs is verplicht")]
        public double Price { get; set; }

        public virtual ICollection<Repair> Repairs { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
