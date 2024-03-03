using SkillSeek.Domain.Base;
using SkillSeek.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillSeek.Domain.Entities;

public class Professional : BaseEntity<Guid>
{
    public Guid UserId { get; set; }
    
    public decimal? PayableAmount { get; set; }
    
    public string CertificationURL { get; set; }
    
    public string ResumeURL { get; set; }
    
    public bool IsActionComplete { get; set; }

    public bool IsApproved { get; set; }
    
    public Guid ServiceId { get; set; }
    
    [ForeignKey("UserId")]
    public virtual User User { get; set; }
    
    [ForeignKey("ServiceId")]
    public virtual Service Service { get; set; }
}