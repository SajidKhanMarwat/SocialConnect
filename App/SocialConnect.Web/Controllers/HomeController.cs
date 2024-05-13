using Microsoft.AspNetCore.Mvc;
using SocialConnect.Application.NewFolder.IServices;
using SocialConnect.Web.Models;
using System.Diagnostics;

namespace SocialConnect.Web.Controllers
{
    public class HomeController : Controller
    {
        internal IUserService _userService;
        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
