using Microsoft.AspNetCore.Mvc;

namespace ZamaPieShop.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Validate()
        {
            return View();
        }
    }
}
