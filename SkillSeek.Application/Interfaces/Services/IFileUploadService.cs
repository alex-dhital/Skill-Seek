using Microsoft.AspNetCore.Http;

namespace SkillSeek.Application.Interfaces.Services;

public interface IFileUploadService
{
    string UploadFile(IFormFile file, string folderPath);
}