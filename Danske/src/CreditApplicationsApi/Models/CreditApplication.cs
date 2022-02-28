
using System.ComponentModel.DataAnnotations;

namespace CreditApplicationsApi.Models
{
    public class CreditApplication
    {
        [Required]
        public decimal CreditAmount { get; set; }
        [Required]
        public decimal TermInMonths { get; set; }
        [Required]
        public decimal PreExistingCreditAmount { get; set; }
    }
}
