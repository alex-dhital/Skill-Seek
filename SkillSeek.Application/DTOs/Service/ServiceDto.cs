namespace SkillSeek.Application.DTOs.Service;

public class ServiceDto
{
    public Guid Id { get; set; }

    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public decimal BasePrice { get; set; }
}