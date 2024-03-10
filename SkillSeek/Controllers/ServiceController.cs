using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillSeek.Domain.Constants;

namespace SkillSeek.Controllers;

[Authorize(Roles = Constants.Roles.Admin)]
public class ServiceController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}