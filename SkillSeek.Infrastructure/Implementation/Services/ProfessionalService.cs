using Microsoft.AspNetCore.Identity;
using SkillSeek.Application.DTOs.Professional;
using SkillSeek.Application.Interfaces.Repositories.Base;
using SkillSeek.Application.Interfaces.Services;
using SkillSeek.Domain.Constants;
using SkillSeek.Domain.Entities;
using SkillSeek.Domain.Entities.Identity;

namespace SkillSeek.Infrastructure.Implementation.Services;

public class ProfessionalService : IProfessionalService
{
    private readonly UserManager<User> _userManager;
    private readonly IGenericRepository _genericRepository;
    private readonly IFileUploadService _fileUploadService;


    public ProfessionalService(IGenericRepository genericRepository, IFileUploadService fileUploadService, UserManager<User> userManager)
    {
        _userManager = userManager;
        _genericRepository = genericRepository;
        _fileUploadService = fileUploadService;
    }

    public void RegisterProfessional(ProfessionalDto professional)
    {
        var usersImagePath = Constants.FilePath.ProfessionalsImagesPath;

        var imageFile = _fileUploadService.UploadFile(professional.ProfileImage, usersImagePath);
        
        var user = new User()
        {
            Name = professional.Name,
            UserName = professional.EmailAddress, 
            Email = professional.EmailAddress,
            ImageURL = imageFile
        };
            
        var result = _userManager.CreateAsync(user, "@ff!N1ty");

        result.Wait();

        var userModel = _genericRepository.GetFirstOrDefault<User>(x => x.Email == professional.EmailAddress);

        var documentsPath = Constants.FilePath.ProfessionalsDocumentsPath;

        var resumeFileUrl = _fileUploadService.UploadFile(professional.Resume, documentsPath);

        var certificationFileUrl = _fileUploadService.UploadFile(professional.Certification, documentsPath);

        var professionalModel = new Professional()
        {
            UserId = userModel.Id,
            IsApproved = false,
            IsActionComplete = false,
            ServiceId = professional.ServiceId,
            CertificationURL = certificationFileUrl,
            ResumeURL = resumeFileUrl
        };

        _genericRepository.Insert(professionalModel);
    }

    public List<ProfessionalDto> GetAllProfessionals(bool? isActionCompleted = null, bool? isApproved = null)
    {
        var professionals = _genericRepository.Get<Professional>(x =>
            (x.IsApproved == isApproved || isApproved == null) &&
            (x.IsActionComplete == isActionCompleted || isActionCompleted == null));

        var users = _genericRepository.Get<User>(x => 
            professionals.Select(y => y.UserId).Contains(x.Id));

        var services = _genericRepository.Get<Service>();
        
        var result = from user in users
            join professional in professionals
                on user.Id equals professional.UserId
            join service in services
                on professional.ServiceId equals service.Id
            select new ProfessionalDto
            {
                Id = professional.Id,
                UserId = user.Id,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                EmailAddress = user.Email,
                ImageURL = user.ImageURL,
                ServiceId = professional.ServiceId,
                Service = service.Title,
                CertificationURL = professional.CertificationURL,
                ResumeURL = professional.ResumeURL,
                IsVerified = professional.IsApproved
            };

        return result.ToList();
    }

    public ProfessionalDto GetProfessionalById(Guid professionalId)
    {
        var professional = _genericRepository.GetById<Professional>(professionalId);

        var user = _genericRepository.GetFirstOrDefault<User>(x => 
            x.Id == professional.UserId);

        var service = _genericRepository.GetFirstOrDefault<Service>(x => 
            x.Id == professional.ServiceId);

        var result = new ProfessionalDto()
        {
            Id = professional.Id,
            UserId = user.Id,
            Name = user.Name,
            PhoneNumber = user.PhoneNumber ?? "",
            EmailAddress = user.Email ?? "",
            ImageURL = user.ImageURL ?? "",
            ServiceId = professional.ServiceId,
            Service = service.Title,
            CertificationURL = professional.CertificationURL,
            ResumeURL = professional.ResumeURL,
            IsVerified = professional.IsApproved
        };

        return result;
    }

    public void ApproveProfessionalStatus(Guid professionalId, bool status)
    {
        var professional = _genericRepository.GetById<Professional>(professionalId);

        professional.IsApproved = status;
        professional.IsActionComplete = true;

        _genericRepository.Update(professional);
    }
}