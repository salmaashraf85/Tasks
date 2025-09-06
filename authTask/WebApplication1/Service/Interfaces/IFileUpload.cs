namespace WebApplication1.Service.Interfaces
{
    public interface IFileUpload
    {
        Task<string> UploadAsync(IFormFile file, string folderName, CancellationToken cancellationToken);
    }
}
