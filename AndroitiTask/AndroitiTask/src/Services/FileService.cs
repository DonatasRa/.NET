
namespace AndroitiTask.Services
{
    public class FileService : IFileService
    {
        public string GetText()
        {
            return File.ReadAllText("Data/Input.txt");
        }
    }
}
