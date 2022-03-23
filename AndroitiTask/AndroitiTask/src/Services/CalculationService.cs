
namespace AndroitiTask.Services
{
    public class CalculationService
    {
        private readonly IFileService _fileService;

        public CalculationService(IFileService fileService)
        {
            _fileService = fileService;
        }

        public int GetCharactersCount()
        {
            var text = _fileService.GetText();
            int count = 0;

            foreach (var character in text)
            {
                count++;
            }

            return count;
        }

        public int GetWordCount()
        {
            var text = _fileService.GetText();
            int wordCounter = 1;
            int l = 0;

            while (l <= text.Length - 1)
            {
                if (text[l]==' ' || text[l]=='\n' || text[l]=='\t')
                {
                    wordCounter++;
                }

                l++;
            }

            return wordCounter;
        }
    }
}
