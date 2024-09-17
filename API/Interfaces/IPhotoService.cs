using CloudinaryDotNet.Actions;

namespace API.Interface;

public interface IPhotoSerivces
{
    Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
    Task<DeletionResult> DeletPhotoAsync(string publicId);
}