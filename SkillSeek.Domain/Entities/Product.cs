using SkillSeek.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillSeek.Domain.Entities;

public class Product : BaseEntity<Guid>
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public decimal Price { get; set; }

    public decimal Price25 { get; set; }
    
    public decimal Price50 { get; set; }
    
    public string ImageURL { get; set; }
    
    public Guid ServiceId { get; set; }
    
    [ForeignKey("ServiceId")]
    public virtual Service Service { get; set; }
}