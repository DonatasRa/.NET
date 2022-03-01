using CreditApplicationsApi.Services;
using CreditApplicationsApi.Models;
using Xunit;
using System;

namespace CreditApplicationApi.UnitTests
{
    public class CreditApplicationServiceTests
    {
        // We want to test more than 1 scenario, research InlineData attribute
        [Fact]
        public void GetCreditAnswer_GivenValidInputs_GetCorrectAnswer()
        {
            //arrange
            var creditApplicationService = new CreditApplicationService();
            var valdiCreditApplication = new CreditApplication()
            {
                CreditAmount = 10000M,
                TermInMonths = 50,
                PreExistingCreditAmount = 20000M
            };

            //act
            var answer = creditApplicationService.GetCreditAnswer(valdiCreditApplication);

            //assert

            // Fluent assertion nuget please
            Assert.True(answer.Decision);
            Assert.Equal(4, answer.InterestRate);
        }

        [Fact]
        public void GetCreditAnswer_GivenOutOfRangeInput_ThrowsArgumentException()
        {
            //arrange
            var creditApplicationService = new CreditApplicationService();
            var invalidCreditApplication = new CreditApplication()
            {
                CreditAmount = 10000000M,
                TermInMonths = 50,
                PreExistingCreditAmount = 20000M
            };

            //act
           

            //assert
            Assert.Throws<ArgumentException>(() => creditApplicationService.GetCreditAnswer(invalidCreditApplication));
        }
    }
}