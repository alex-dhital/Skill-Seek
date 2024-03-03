using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SkillSeek.Application.DTOs.Product;

public class ProductDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }	

    public string Description { get; set; }	
    
    [Display(Name = "Service Type")]
    public Guid ServiceId { get; set; }
    
    public string Service { get; set; }
    
    [Display(Name = "Price for 20 Items")]
    public decimal Price25 { get; set; }

    [Display(Name = "Price for 50 Items")]
    public decimal Price50 { get; set; }

    [Display(Name = "Image URL")]
    public string? ImageURL { get; set; }
    
    public IFormFile? Image { get; set; }
    
    public decimal Price { get; set; }
}