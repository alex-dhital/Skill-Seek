using System.ComponentModel.DataAnnotations.Schema;
using SkillSeek.Domain.Base;

namespace SkillSeek.Domain.Entities;

public class OrderDetail : BaseEntity<Guid>
{
    public Guid OrderId { get; set; }
    
    public Guid ProductId { get; set; }
    
    public int Quantity { get; set; }
    
    public decimal TotalAmount { get; set; }
    
    [ForeignKey("OrderId")]
    public virtual Order Order { get; set; }
    
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }
}