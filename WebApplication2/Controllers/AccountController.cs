using Microsoft.AspNetCore.Mvc;

namespace EmployeeManangement.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
