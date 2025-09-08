using WebApplication1.Service.Interfaces;
using WebApplication1.Settings;

namespace WebApplication1.Service.Implementation
{
    public class FileService(ServerSetting serverSetting) : IFileService
    {
        private readonly string _mainDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

        public string? GetFilePath(string? filePath)
        {
            return string.IsNullOrEmpty(filePath) ? null : Path.Combine(_mainDirectory, filePath);
        }
    }

}
