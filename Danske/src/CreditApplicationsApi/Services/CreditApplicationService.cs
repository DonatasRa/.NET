
using CreditApplicationsApi.Helpers;
using CreditApplicationsApi.Models;
using System;

namespace CreditApplicationsApi.Services
{
    public class CreditApplicationService
    {
        public CreditAnswer GetCreditAnswer(CreditApplication creditApplication)
        {
            
            var answer = new CreditAnswer
            {
                Decision = false,
                InterestRate = 0M
            };

            if (!((creditApplication.CreditAmount >= 2000M) && (creditApplication.CreditAmount <= 69000M)))
            {
                throw new ArgumentException($"Credit Amount: {creditApplication.CreditAmount} is out of Range!");

            } else {

                
                var interestRateAnswer = StaticCreditHelper.GetInterestRate(creditApplication);

                answer.Decision = true;
                answer.InterestRate = interestRateAnswer;
       
            }

            return answer;
        }
    }
}
