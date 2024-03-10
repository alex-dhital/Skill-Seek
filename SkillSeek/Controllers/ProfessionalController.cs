using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillSeek.Domain.Constants;

namespace SkillSeek.Controllers;

[Authorize(Roles = Constants.Roles.Admin)]
public class ProfessionalController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Approvals()
    {
        return View();
    }
}