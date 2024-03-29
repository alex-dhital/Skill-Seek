﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SkillSeek.Application.Interfaces.Services;
using SkillSeek.Domain.Constants;

namespace SkillSeek.Infrastructure.Implementation.Services;

public class FileUploadService : IFileUploadService
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileUploadService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public string UploadFile(IFormFile file, string folderPath)
    {
        var extension = Path.GetExtension(file.FileName);
        
        if (!Directory.Exists(Path.Combine(_webHostEnvironment.WebRootPath, folderPath)))
        {
            Directory.CreateDirectory(Path.Combine(_webHostEnvironment.WebRootPath, folderPath));
        }
        
        var uploadedDocumentPath = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
        
        var fileName = extension.SetUniqueFileName();
        
        using var stream = new FileStream(Path.Combine(uploadedDocumentPath, fileName), FileMode.Create);
            
        file.CopyTo(stream);
            
        return fileName;
    }
}