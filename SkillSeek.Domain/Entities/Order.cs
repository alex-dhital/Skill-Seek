using SkillSeek.Domain.Base;
using SkillSeek.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillSeek.Domain.Entities;

public class Order : BaseEntity<Guid>
{
    public Guid UserId { get; set; }
    
    public DateTime OrderDate { get; set; }
    
    public string Description { get; set; }
    
    public decimal OrderTotalAmount { get; set; }
    
    public string OrderStatus { get; set; }
    
    public string PaymentStatus { get; set; }
    
    public string? TrackingNumber { get; set; }
    
    public string? Carrier { get; set; }
    
    public DateTime? PaymentDate { get; set; }
    
    public string? SessionId { get; set; }
    
    public string? PaymentIntendId { get; set; }
    
    [ForeignKey("UserId")]
    public virtual User User { get; set; }
}