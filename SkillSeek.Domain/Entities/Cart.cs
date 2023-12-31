using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SkillSeek.Domain.Base;
using SkillSeek.Domain.Entities.Identity;

namespace SkillSeek.Domain.Entities;

public class Cart : BaseEntity<Guid>
{
    public Guid ProductId { get; set; }

    public Guid UserId { get; set; }

    [Range(1, 1000, ErrorMessage = "Enter a value from 1 to 1000")]
    public int Count { get; set; }

    [NotMapped]
    public double Price { get; set; }
    
    [ForeignKey("ProductId")]
    public virtual Product? Product { get; set; }

    [ForeignKey("UserId")]
    public virtual User? User { get; set; }
}