namespace WebApplication1.Interfaces
{
    public interface IFileUpload
    {
        Task<string> UploadAsync(IFormFile file, string folderName, CancellationToken cancellationToken);
    }
}
