using SkillSeek.Domain.Base;

namespace SkillSeek.Domain.Entities;

public class Service : BaseEntity<Guid>
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public decimal BasePrice { get; set; }
}