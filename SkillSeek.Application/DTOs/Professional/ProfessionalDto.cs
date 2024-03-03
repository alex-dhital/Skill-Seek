using Microsoft.AspNetCore.Http;

namespace SkillSeek.Application.DTOs.Professional;

public class ProfessionalDto
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
    
    public string Name { get; set; }
    
    public string ImageURL { get; set; }
    
    public IFormFile ProfileImage { get; set; }
    
    public string EmailAddress { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public Guid ServiceId { get; set; }
    
    public string Service { get; set; }
    
    public bool IsVerified { get; set; }
    
    public string ResumeURL { get; set; }
    
    public IFormFile Resume { get; set; }
    
    
    public string CertificationURL { get; set; }
    
    public IFormFile Certification { get; set; }
}