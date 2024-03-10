using Microsoft.AspNetCore.Mvc;

namespace SkillSeek.Controllers;

public class CartController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}