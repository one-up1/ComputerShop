using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComputerShop.Data.Models
{
    public class Repair
    {
        public int Id { get; set; }

        [Display(Name = "Naam")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Naam is verplicht")]
        public string Name { get; set; }

        [Display(Name = "Status")]
        public Status Status { get; set; }

        [Display(Name = "Omschrijving")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Omschrijving is verplicht")]
        public string Description { get; set; }

        [Display(Name = "Startdatum")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Startdatum is verplicht")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Einddatum")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> EndDate { get; set; }

        [Display(Name = "Oplossing")]
        [DataType(DataType.MultilineText)]
        public string Solution { get; set; }

        [Display(Name = "Onderdelen")]
        public virtual ICollection<Part> Parts { get; set; }
    }
}
