using System.ComponentModel.DataAnnotations.Schema;
using SkillSeek.Domain.Base;
using SkillSeek.Domain.Entities.Identity;

namespace SkillSeek.Domain.Entities;

public class Appointment : BaseEntity<Guid>
{
    public Guid UserId { get; set; }
    
    public Guid? ProfessionalId { get; set; }
    
    public string RequestDescription { get; set; }
    
    public DateTime BookedDate { get; set; } = DateTime.Now;

    public DateTime AppointedDate { get; set; }

    public DateTime? FinalizedDate { get; set;}

    public string? AdminRemarks { get; set; }

    public string? ProfessionalRemarks { get; set; }
    
    public string? FeedbackDescription { get; set; }

    public string ActionStatus { get; set; }

    public string PaymentStatus { get; set; }

    [ForeignKey("UserId")]
    public virtual User? User { get; set; }

    [ForeignKey("ProfessionalId")]
    public virtual Professional? Professional { get; set; }
}