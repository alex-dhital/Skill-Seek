using Microsoft.AspNetCore.Mvc;

namespace SkillSeek.Controllers;

public class OrderController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}