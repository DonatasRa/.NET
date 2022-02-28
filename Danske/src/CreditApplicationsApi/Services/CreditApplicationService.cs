
using CreditApplicationsApi.Models;
using System;

namespace CreditApplicationsApi.Services
{
    public class CreditApplicationService
    {
        public CreditApplicationService()
        {
            
        }

        public CreditAnswer GetCreditAnswer(CreditApplication creditApplication)
        {
            
            var answer = new CreditAnswer()
            {
                Decision = false,
                InterestRate = 0M
            };

            if (!((creditApplication.CreditAmount >= 2000M) && (creditApplication.CreditAmount <= 69000M)))
            {
                throw new ArgumentException($"Credit Amount: {creditApplication.CreditAmount} is out of Range!");

            } else {
                
                var interestRateAsnwer = GetInterestRate(creditApplication);

                answer.Decision = true;
                answer.InterestRate = interestRateAsnwer;
       
            }

            return answer;
        }

        private decimal GetInterestRate(CreditApplication creditApplication)
        {
            var interestRate = 0;

            var totalCreditAmount = creditApplication.CreditAmount + creditApplication.PreExistingCreditAmount;

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
