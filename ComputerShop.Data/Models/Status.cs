using System.ComponentModel.DataAnnotations;

namespace ComputerShop.Data.Models
{
    public enum Status
    {
        [Display(Name = "In afwachting")]
        Pending,

        [Display(Name = "In behandeling")]
        InProgress,

        [Display(Name = "Wacht op onderdelen")]
        WaitingForParts,

        [Display(Name = "Klaar")]
        Completed
    }
}
