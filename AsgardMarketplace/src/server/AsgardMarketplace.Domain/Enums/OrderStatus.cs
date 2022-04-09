using System.ComponentModel.DataAnnotations;

namespace AsgardMarketplace.Domain.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "Created")]
        Created,
        [Display(Name = "Paid")]
        Paid,
        [Display(Name = "Completed")]
        Completed
    }
}
