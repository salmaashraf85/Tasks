using WebApplication1.Interfaces;
namespace WebApplication1.Service
{
    public class FileUpload : IFileUpload
    {
        public async Task<string> UploadAsync(IFormFile file, string folderName, CancellationToken cancellationToken)
        {
            if (file == null) return null;


            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(folderPath, fileName);

            await using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream, cancellationToken);

            return $"{folderName}/{fileName}";

        }
    }
}
