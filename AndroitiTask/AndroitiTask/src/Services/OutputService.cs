using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroitiTask.Services
{
    public class OutputService
    {
        private readonly CalculationService _calculationService;

        public OutputService(CalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        public void PrintCharCount()
        {
            Console.WriteLine($"Number of Characters: {_calculationService.GetCharactersCount()}");
            Console.WriteLine($"Number of Words: {_calculationService.GetWordCount()}");
            Console.ReadLine();
        }
    }
}
