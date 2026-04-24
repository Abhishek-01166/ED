using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ED.Controllers;

[Authorize]
public class MenuController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
