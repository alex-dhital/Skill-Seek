using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillSeek.Domain.Constants;

namespace SkillSeek.Controllers;

public class ProductController : Controller
{
    [Authorize(Roles = Constants.Roles.Admin)]
    public IActionResult Index()
    {
        return View();
    }
    
    [Authorize(Roles = Constants.Roles.Customer)]
    public IActionResult Order()
    {
        return View();
    }
}