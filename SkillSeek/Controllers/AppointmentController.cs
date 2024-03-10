using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillSeek.Domain.Constants;

namespace SkillSeek.Controllers;

public class AppointmentController : Controller
{
    [Authorize(Roles = Constants.Roles.Customer)]
    public IActionResult Index()
    {
        return View();
    }

    [Authorize(Roles = Constants.Roles.Customer)]
    public IActionResult Booked()
    {
        return View();
    }
    
    [Authorize(Roles = Constants.Roles.Admin)]
    public IActionResult Booking()
    {
        return View();
    }
    
    [Authorize(Roles = Constants.Roles.Admin)]
    public IActionResult History()
    {
        return View();
    }
}