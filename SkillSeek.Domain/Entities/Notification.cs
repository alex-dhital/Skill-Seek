using System.ComponentModel.DataAnnotations.Schema;
using SkillSeek.Domain.Base;
using SkillSeek.Domain.Entities.Identity;

namespace SkillSeek.Domain.Entities;

public class Notification : BaseEntity<Guid>
{
    public Guid? SenderId { get; set; }
    
    public string? SenderEntity { get; set; }
    
    public Guid ReceiverId { get; set; }
    
    public string ReceiverEntity { get; set; }
    
    public bool IsSeen { get; set; }
    
    [ForeignKey("SenderId")]
    public virtual User Sender { get; set; }
    
    [ForeignKey("ReceiverId")]
    public virtual User Receiver { get; set; }
}