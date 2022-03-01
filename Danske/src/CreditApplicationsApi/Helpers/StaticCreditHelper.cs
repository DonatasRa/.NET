using CreditApplicationsApi.Models;

namespace CreditApplicationsApi.Helpers
{
    static class StaticCreditHelper
    {
        public static decimal GetInterestRate(CreditApplication creditApplication)
        {
            var interestRate = 0;
            var totalCreditAmount = creditApplication.CreditAmount + creditApplication.PreExistingCreditAmount;

            // maybe modify this to switch statement
            if (totalCreditAmount < 20000)
            {
                interestRate = 3;
            }
            if (totalCreditAmount >= 20000 && totalCreditAmount <= 39999.99M)
            {
                interestRate = 4;
            }
            if (totalCreditAmount >= 40000 && totalCreditAmount <= 59999.99M)
            {
                interestRate = 5;
            }
            if (totalCreditAmount > 60000)
            {
                interestRate = 6;
            }

            return interestRate;
        }
    }
}
